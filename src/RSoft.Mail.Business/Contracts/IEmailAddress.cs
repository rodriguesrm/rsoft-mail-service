namespace RSoft.Mail.Business.Contracts
{

    /// <summary>
    /// Email address interface
    /// </summary>
    public interface IEmailAddress
    {

        /// <summary>
        /// E-mmail address of the sender or recipient
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Name of the sender or recipient
        /// </summary>
        public string Name { get; set; }

    }
}
