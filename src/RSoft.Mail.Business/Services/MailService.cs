using RSoft.Mail.Business.Contracts;
using RSoft.Mail.Business.Models;
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
        private readonly ISender _sender;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new mail-service instance
        /// </summary>
        /// <param name="mailRepository">Mail repository object</param>
        /// <param name="sender">Mail sender oject</param>
        public MailService(IMailRepository mailRepository, ISender sender)
        {
            _mailRepository = mailRepository;
            _sender = sender;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Send e-mail
        /// </summary>
        /// <param name="message">Message details</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        public async Task<(SendMailResult, Guid)> SendMailAsync(IMessage message, CancellationToken cancellationToken = default)
        {

            Guid requestId = await _mailRepository.SaveRequestAsync(message, cancellationToken);
            SendMailResult mailResult = await _sender.SendMailAsync(message, cancellationToken);
            return (mailResult, requestId);

        }

        #endregion

    }

}
