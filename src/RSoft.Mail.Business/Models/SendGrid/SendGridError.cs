using System.Collections.Generic;

namespace RSoft.Mail.Business.Models.SendGrid
{

    /// <summary>
    /// SendGrid sending error model
    /// </summary>
    public class SendGridError
    {

        /// <summary>
        /// List of errors
        /// </summary>
        public IEnumerable<SendGridErrorDetail> Errors { get; set; }

    }
}
