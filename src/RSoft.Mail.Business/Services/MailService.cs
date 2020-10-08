using Microsoft.Extensions.Options;
using RSoft.Mail.Business.Contracts;
using RSoft.Mail.Business.Models;
using RSoft.Mail.Business.Options;
using RSoft.Mail.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSoft.Mail.Business.Services
{

    /// <summary>
    /// Email sending service class-object
    /// </summary>
    public class MailService : IMailService
    {

        #region Local objects/variables

        private readonly IMailRepository _mailRepository;
        private readonly ISender _sender;
        private readonly bool _isProduction;
        private readonly RedirectToOptions _redirectOptions;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new mail-service instance
        /// </summary>
        /// <param name="mailRepository">Mail repository object</param>
        /// <param name="sender">Mail sender oject</param>
        public MailService(IMailRepository mailRepository, ISender sender, IOptions<RedirectToOptions> options)
        {
            _mailRepository = mailRepository;
            _sender = sender;
            _isProduction = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "production";
            _redirectOptions = options?.Value;
        }

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public Task<(SendMailResult, Guid)> SendMail(IMessage message)
            => SendMail(message, null);

        ///<inheritdoc/>
        public async Task<(SendMailResult, Guid)> SendMail(IMessage message, IEmailAddress redirectTo)
        {

            Guid requestId = await _mailRepository.SaveRequestAsync(message);

            IMessageHandle msgToSend;
            if (!_isProduction && redirectTo == null)
            {
                msgToSend =
                    new Message
                    (
                        message.Subject,
                        message.Content,
                        message.From,
                        message.To.ToList(),
                        message.Cc.ToList(),
                        message.Cco.ToList(),
                        message.Files.ToList(),
                        message.EnableHtml
                    );
            }
            else
            {
                msgToSend =
                    new Message
                    (
                        message.Subject,
                        message.Content,
                        message.From,
                        new List<IEmailAddress>() { redirectTo ?? _redirectOptions },
                        null,
                        null,
                        message.Files.ToList(),
                        message.EnableHtml
                    );

            }

            if (message.Headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> header in message.Headers)
                {
                    msgToSend.AddHeader(header.Key, header.Value);
                }
            }

            SendMailResult mailResult = await _sender.SendMailAsync(msgToSend);

            return (mailResult, requestId);

        }

        #endregion

    }

}
