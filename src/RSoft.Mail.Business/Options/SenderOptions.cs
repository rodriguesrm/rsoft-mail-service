using RSoft.Mail.Business.Enums;

namespace RSoft.Mail.Business.Options
{

    /// <summary>
    /// Mail sender parameters options
    /// </summary>
    public class SenderOptions
    {

        /// <summary>
        /// Sender type
        /// </summary>
        public SenderType Type { get; set; }

        /// <summary>
        /// Smtp parameters options
        /// </summary>
        public SmtpOptions Smtp { get; set; }

        /// <summary>
        /// Send grid parameters options
        /// </summary>
        public SendGridOptions SendGrid { get; set; }

        /// <summary>
        /// Recipient's e-mail to redirect (not working in production)
        /// </summary>
        public RedirectToOptions RedirectTo { get; set; }

    }

}
