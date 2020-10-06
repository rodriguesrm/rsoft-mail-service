using System.Collections.Generic;

namespace RSoft.Mail.Business.Contracts
{

    /// <summary>
    /// Message sending interface
    /// </summary>
    public interface IMessage
    {

        /// <summary>
        /// A list of Message Headers
        /// </summary>
        IDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Get or set sender's e-mail
        /// </summary>
        IEmailAddress From { get; set; }

        /// <summary>
        /// Get or set recipient's e-mail
        /// </summary>
        IEnumerable<IEmailAddress> To { get; set; }

        /// <summary>
        /// CC e-mail recipient
        /// </summary>
        IEnumerable<IEmailAddress> Cc { get; set; }

        /// <summary>
        /// CCO e-mail recipient
        /// </summary>
        IEnumerable<IEmailAddress> Cco { get; set; }

        /// <summary>
        /// Gets or sets the subject of your email.
        /// </summary>
        string Subject { get; set; }

        /// <summary>
        /// Message content
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// List of files to be sent as an attachment
        /// </summary>
        IEnumerable<IFileAttachment> Attachments { get; set; }

    }
}
