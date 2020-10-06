namespace RSoft.Mail.Business.Contracts
{

    /// <summary>
    /// File attachment interface
    /// </summary>
    public interface IFileAttachment
    {

        /// <summary>
        /// Gets or sets a unique id that you specify for the attachment
        /// </summary>
        string ContentId { get; set; }

        /// <summary>
        /// Gets or sets the filename of the attachment.
        /// </summary>
        string Filename { get; set; }

        /// <summary>
        /// Gets or sets the mime type of the content you are attaching. For example, application/pdf
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the Base64 encoded content of the attachment.
        /// </summary>
        string Content { get; set; }

    }
}
