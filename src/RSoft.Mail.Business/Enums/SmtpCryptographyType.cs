using System.ComponentModel;

namespace RSoft.Mail.Business.Enums
{

    /// <summary>
    /// Smtp criptography type
    /// </summary>
    public enum SmtpCryptographyType
    {

        /// <summary>
        /// No encryption
        /// </summary>
        [Description("No encryption")]
        None = 0,

        /// <summary>
        /// SSL/TLS criptography
        /// </summary>
        [Description("SSL/TLS criptography")]
        SSL_TLS = 1,

        /// <summary>
        /// STARTTLS Criptography
        /// </summary>
        [Description("STARTTLS Criptography")]
        STARTTLS = 2,

        /// <summary>
        /// Automatic encryption selection
        /// </summary>
        [Description("Automatic encryption selection")]
        Automatic = 3

    }
}
