using RSoft.Mail.Contract;

namespace RSoft.Mail.Business.Models
{

    /// <summary>
    /// File attachment detail
    /// </summary>
    public class FileAttachment : IFileAttachment
    {

        #region Constructors

        /// <summary>
        /// Create a new file attachment object instance
        /// </summary>
        /// <param name="filename">Filename of the attachment</param>
        /// <param name="type">File mime-type</param>
        /// <param name="content">File content (base64 string)</param>
        public FileAttachment(string filename, string type, string content)
        {
            Filename = filename;
            Type = type;
            Content = content;
        }

        #endregion

        #region Properties

        ///<inheritdoc/>
        public string Filename { get; private set; }

        ///<inheritdoc/>
        public string Type { get; private set; }

        ///<inheritdoc/>
        public string Content { get; private set; }

        #endregion

    }
}
