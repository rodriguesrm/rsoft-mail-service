using RSoft.Mail.Business.Contracts;

namespace RSoft.Mail.Business.Models
{

    /// <summary>
    /// E-Mail address object
    /// </summary>
    public class EmailAddress : IEmailAddress
    {

        #region Constructors

        /// <summary>
        /// Create a new e-mail address object instance
        /// </summary>
        /// <param name="email">E-mail address of the sender or recipient</param>
        public EmailAddress(string email) : this(email, null) { }

        /// <summary>
        /// Create a new e-mail address object instance
        /// </summary>
        /// <param name="email">E-mail address of the sender or recipient</param>
        /// <param name="name">Name of the sender or recipient</param>
        public EmailAddress(string email, string name)
        {
            Email = email;
            Name = name;
        }

        #endregion

        #region Properties

        ///<inheritdoc/>
        public string Email { get; private set; }

        ///<inheritdoc/>
        public string Name { get; private set; }

        #endregion

    }
}
