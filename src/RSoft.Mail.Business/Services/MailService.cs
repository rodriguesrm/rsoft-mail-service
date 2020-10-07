using Microsoft.Extensions.Options;
using RSoft.Mail.Business.Contracts;
using RSoft.Mail.Business.Models;
using RSoft.Mail.Business.Options;
using RSoft.Mail.Business.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSoft.Mail.Business.Services
{

    /// <summary>
    /// Email sending service class-object
    /// </summary>
    public class MailService
    {

        #region Local objects/variables

        private readonly IMailRepository _mailRepository;
        private readonly IMailSender _mailSender;
        private readonly MailSenderOptions _options;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new mail-service instance
        /// </summary>
        /// <param name="mailRepository">Mail repository object</param>
        /// <param name="mailSender">Mail sender oject</param>
        public MailService(IMailRepository mailRepository, IMailSender mailSender, IOptions<MailSenderOptions> options)
        {
            _mailRepository = mailRepository;
            _mailSender = mailSender;
            _options = options?.Value;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Send e-mail
        /// </summary>
        /// <param name="message">Message details</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        public async Task<SendMailResult> SendMailAsync(IMessage message, CancellationToken cancellationToken = default)
        {

            Guid requestId = await _mailRepository.SaveRequestAsync(message, cancellationToken);
            SendMailResult mailResult = null;

            switch (_options.Type)
            {
                // await _mailSender.SendMailAsync(message, cancellationToken);
                //TODO: ***** PAREI AQUI *****
                case Enums.SenderType.Smtp:
                    break;
                case Enums.SenderType.SendGrid:
                    break;
                default:
                    break;
            }
        }

        #endregion

    }

}
