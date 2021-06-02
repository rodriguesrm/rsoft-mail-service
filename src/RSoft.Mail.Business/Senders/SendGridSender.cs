using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RSoft.Logs.Extensions;
using RSoft.Mail.Business.Contracts;
using RSoft.Mail.Business.Enums;
using RSoft.Mail.Business.Models;
using RSoft.Mail.Business.Models.SendGrid;
using RSoft.Mail.Business.Options;
using RSoft.Mail.Contract;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EmailAddress = SendGrid.Helpers.Mail.EmailAddress;

namespace RSoft.Mail.Business.Senders
{

    /// <summary>
    /// Sendgrid mail sender
    /// </summary>
    public sealed class SendGridSender : ISender
    {

        #region Local objects/variables

        private readonly SendGridOptions _options;
        private readonly ISendGridClient _client;
        private readonly ILogger<SendGridSender> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new sendgrid sender object instance
        /// </summary>
        /// <param name="client">Sendgrid client object</param>
        /// <param name="options">Sendgrid options parameters object</param>
        /// <param name="logger">Logger service</param>
        public SendGridSender(ISendGridClient client, IOptions<SendGridOptions> options, ILogger<SendGridSender> logger)
        {
            _client = client;
            _options = options?.Value;
            _logger = logger;
        }

        #endregion

        #region Properties

        ///<inheritdoc/>
        public SenderType SenderType => SenderType.SendGrid;

        #endregion

        #region Public methods

        ///<inheritdoc/>
        public async Task<SendMailResult> SendMailAsync(IMessage message, CancellationToken cancellationToken = default)
        {

            SendGridMessage msg = new SendGridMessage()
            {
                From = new EmailAddress(message.From.Email, message.From.Name),
                Subject = message.Subject
            };

            if (message.ReplyTo != null)
                msg.ReplyTo = new EmailAddress(message.ReplyTo.Email, message.ReplyTo.Name);

            if (message.Headers.Count > 0)
                msg.AddHeaders(message.Headers.ToDictionary(k => k.Key, v => v.Value));

            if (message.EnableHtml)
                msg.HtmlContent = message.Content;
            else
                msg.PlainTextContent = message.Content;

            msg.AddTos(message.To.Select(s => new EmailAddress(s.Email, s.Name)).ToList());

            if (message.Cc.Count > 0)
                msg.AddCcs(message.Cc.Select(s => new EmailAddress(s.Email, s.Name)).ToList());

            if (message.Bcc.Count > 0)
                msg.AddBccs(message.Bcc.Select(s => new EmailAddress(s.Email, s.Name)).ToList());

            if (message.Files.Count > 0)
            {
                msg.Attachments = message.Files.Select(s => new Attachment()
                {
                    Filename = s.Filename,
                    Type = s.Type,
                    Content = s.Content,
                    Disposition = "attachment"
                }).ToList();
            }

            IDictionary<string, string> errors = new Dictionary<string, string>();
            Response response = await _client.SendEmailAsync(msg, cancellationToken);
            bool success = (response.StatusCode == HttpStatusCode.Accepted);
            if (!success)
            {
                string errorMessage = string.Empty;
                string body = await response.Body.ReadAsStringAsync();
                _logger.LogWarning("Fail to send e-mail in SendGrid Service, Response Status Code: {SendGridStatusCode}, Response Body: {SendGridStatusResponseBody}", response.StatusCode, body.AsJson());
                if (!string.IsNullOrWhiteSpace(body))
                {
                    SendGridError sendGridResult = JsonSerializer.Deserialize<SendGridError>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                    errorMessage = string.Join('|', sendGridResult.Errors.Select(x => x.Message));
                }
                else
                {
                    errorMessage = response.StatusCode.ToString();
                }
                errors.Add("Email", $"Failed to send email => {errorMessage}");
            }

            return new SendMailResult(success, errors);

        }

        #endregion

    }
}
