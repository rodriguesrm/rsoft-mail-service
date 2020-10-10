namespace RSoft.Mail.Business.Contracts
{

    /// <summary>
    /// Message sending interface
    /// </summary>
    public interface IMessageHandle : IMessage
    {

        #region Methods

        /// <summary>
        /// Add a recipient in list
        /// </summary>
        /// <param name="recipient">E-mail/Name object</param>
        void AddRecipient(IEmailAddress recipient);

        /// <summary>
        /// Add a cc recipient in list
        /// </summary>
        /// <param name="recipient">E-mail/Name object</param>
        void AddCcRecipient(IEmailAddress recipient);

        /// <summary>
        /// Add a bcc recipient in list
        /// </summary>
        /// <param name="recipient">E-mail/Name object</param>
        void AddBccRecipient(IEmailAddress recipient);

        /// <summary>
        /// Add a file to attachment list
        /// </summary>
        /// <param name="file">File to attach</param>
        void AddAttachment(IFileAttachment file);


        /// <summary>
        /// Add header in message
        /// </summary>
        /// <param name="key">Header key name</param>
        /// <param name="value">Header key value</param>
        void AddHeader(string key, string value);

        #endregion

    }
}
