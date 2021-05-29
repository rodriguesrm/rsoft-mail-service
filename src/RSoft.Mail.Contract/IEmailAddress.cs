namespace RSoft.Mail.Contract
{

    /// <summary>
    /// Email address interface
    /// </summary>
    public interface IEmailAddress
    {

        /// <summary>
        /// E-mail address of the sender or recipient
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Name of the sender or recipient
        /// </summary>
        public string Name { get; }

    }
}
