using RSoft.Mail.Business.Contracts;

namespace RSoft.Mail.Business.Options
{

    /// <summary>
    /// E-mail redirect to options parameters
    /// </summary>
    public class RedirectToOptions : IEmailAddress
    {

        /// <summary>
        /// E-mail address of the recipient
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Name of the recipient
        /// </summary>
        public string Name { get; }

    }
}
