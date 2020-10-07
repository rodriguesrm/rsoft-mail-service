using System.ComponentModel;

namespace RSoft.Mail.Business.Enums
{

    /// <summary>
    /// Sender type enum
    /// </summary>
    public enum SenderType
    {

        /// <summary>
        /// Sender by smtp protocol
        /// </summary>
        [Description("Sender by smtp protocol")]
        Smtp = 1,

        /// <summary>
        /// Sender by sendgrid cloud service
        /// </summary>
        [Description("Sender by sendgrid cloud service")]
        SendGrid = 2

    }
}
