using RSoft.Mail.Business.Contracts;
using RSoft.Mail.Business.Models;
using RSoft.Mail.Business.Repositories;
using System;
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

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new mail-service instance
        /// </summary>
        /// <param name="mailRepository">Mail repository object</param>
        public MailService(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Send e-mail
        /// </summary>
        /// <param name="message">Message details</param>
        public async Task<SendMailResult> SendMailAsync(IMessage message)
        {
            //BUG: NotImplementedException
            throw new NotImplementedException();
        }

        #endregion

    }

}
