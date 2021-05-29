namespace RSoft.Mail.Contract
{

    /// <summary>
    /// File attachment interface
    /// </summary>
    public interface IFileAttachment
    {

        /// <summary>
        /// Gets the filename of the attachment.
        /// </summary>
        string Filename { get; }

        /// <summary>
        /// Gets the mime type of the content you are attaching. For example, application/pdf
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the Base64 encoded content of the attachment.
        /// </summary>
        string Content { get; }

    }
}
