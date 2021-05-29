using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using RSoft.Mail.Web.Grpc.Contracts;
using IRSoftMessage = RSoft.Mail.Contract.IMessage;

namespace RSoft.Mail.Web.Grpc.Client
{

    /// <summary>
    /// RSoft gRpc Mail Service provider
    /// </summary>
    public sealed class GrpcMailServiceProvider : IGrpcMailServiceProvider
    {

        #region Local Variables/Objects

        private ILogger<GrpcMailServiceProvider> _logger = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new GrpcMailServiceProvider instance
        /// </summary>
        public GrpcMailServiceProvider() : this(null) { }

        /// <summary>
        /// Create a new GrpcMailServiceProvider instance
        /// </summary>
        /// <param name="loggerFactory">Loger factory</param>
        public GrpcMailServiceProvider(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GrpcMailServiceProvider>();
        }

        #endregion

        #region Local methods

        /// <summary>
        /// Create authenticated channel to gRpc Service Client
        /// </summary>
        /// <param name="address">Url address</param>
        /// <param name="token">Token authentication</param>
        private GrpcChannel CreateAuthenticatedChannel(string address, string token)
        {

            CallCredentials credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(token))
                {
                    metadata.Add("Authorization", $"Bearer {token}");
                }
                return Task.CompletedTask;
            });

            // SslCredentials is used here because this channel is using TLS.
            // Channels that aren't using TLS should use ChannelCredentials.Insecure instead.
            GrpcChannel channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });
            return channel;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="message">Message data</param>
        /// <param name="urlService">Mail service url</param>
        /// <param name="token">Token authentication</param>
        /// <param name="redirectTo">E-mail to redirect (use for developer/stage/testing environment)</param>
        public Task<MailSendReply> SendMail(IRSoftMessage message, string urlService, string token = null, string redirectTo = null)
        {

            if (message == null)
                throw new ArgumentNullException(nameof(message));

            if (string.IsNullOrWhiteSpace(urlService))
                throw new ArgumentNullException(nameof(urlService));

            _logger?.LogInformation("Process SendMail command");

            using GrpcChannel channel = CreateAuthenticatedChannel(urlService, token);
            MailSender.MailSenderClient client = new MailSender.MailSenderClient(channel);

            MailSendRequest request = new MailSendRequest()
            {
                From = new MailSendRequest.Types.Email() { Address = message.From.Email, Name = message.From.Name },
                Content = message.Content,
                EnableHtml = message.EnableHtml,
                Subject = message.Subject
            };

            if (string.IsNullOrWhiteSpace(redirectTo))
                request.RedirectTo = redirectTo;

            if (message.Cc?.Count > 0)
                foreach (Contract.IEmailAddress item in message.Cc)
                    request.Cc.Add(new MailSendRequest.Types.Email() { Address = item.Email, Name = item.Name });

            if (message.Bcc?.Count > 0)
                foreach (Contract.IEmailAddress item in message.Bcc)
                    request.Bcc.Add(new MailSendRequest.Types.Email() { Address = item.Email, Name = item.Name });

            if (message.Files?.Count > 0)
                foreach (Contract.IFileAttachment item in message.Files)
                    request.Files.Add(new MailSendRequest.Types.FileAttachment()
                    {
                        Type = item.Type,
                        Filename = item.Filename,
                        Content = item.Content
                    });

            MailSendReply reply;
            try
            {

                _logger?.LogInformation("Call gRPC Service on {urlService}", urlService);
                reply = client.Send(request);
                _logger?.LogInformation("SendMail Success");

            }
            catch (RpcException rpcEx)
            {
                reply = new MailSendReply()
                {
                    Success = false,
                    Errors = rpcEx.Message
                };
                _logger?.LogInformation("SendMail FAIL, {errorMessage}", rpcEx.Message);
            }
            catch (Exception ex)
            {
                reply = new MailSendReply()
                {
                    Success = false,
                    Errors = ex.Message
                };
                _logger?.LogInformation("SendMail FAIL, {errorMessage}", ex.Message);
            }

            return Task.FromResult(reply);
        }

        #endregion

    }
}
