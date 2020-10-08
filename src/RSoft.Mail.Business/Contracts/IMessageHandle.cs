namespace RSoft.Mail.Business.Contracts
{

    /// <summary>
    /// Message sending interface
    /// </summary>
    public interface IMessageHandle
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
        /// Add a cco recipient in list
        /// </summary>
        /// <param name="recipient">E-mail/Name object</param>
        void AddCcoRecipient(IEmailAddress recipient);

        /// <summary>
        /// Add a file to attachment list
        /// </summary>
        /// <param name="file">File to attach</param>
        void Attachment(IFileAttachment file);

        #endregion

    }
}
