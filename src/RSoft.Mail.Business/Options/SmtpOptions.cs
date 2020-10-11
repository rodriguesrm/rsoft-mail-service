using RSoft.Mail.Business.Enums;

namespace RSoft.Mail.Business.Options
{

    /// <summary>
    /// Smtp parameters options
    /// </summary>
    public class SmtpOptions
    {

        /// <summary>
        /// Server host name or ip
        /// </summary>
        public string SmtpServer { get; set; }

        /// <summary>
        /// Server host port
        /// </summary>
        public string SmtpPort { get; set; }

        /// <summary>
        /// Server host criptography
        /// </summary>
        public SmtpCryptographyType CryptographyType { get; set; }

        /// <summary>
        /// Sender e-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Sender username to authenticate in smtp server
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User password to authenticate in smtp server
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Indicates the use of SPA in smtp requests
        /// </summary>
        public bool UseSPA { get; set; }

    }

}
