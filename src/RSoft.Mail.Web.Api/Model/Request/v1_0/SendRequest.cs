using RSoft.Framework.Web.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSoft.Mail.Web.Api.Model.Request.v1_0
{

    /// <summary>
    /// Send mail request model
    /// </summary>
    public class SendRequest
    {

        /// <summary>
        /// Sender's e-mail
        /// </summary>
        [Required(ErrorMessage = "Sender is required")]
        public EmailRequest From { get; set; }

        /// <summary>
        /// Reply-to's e-mail
        /// </summary>
        public EmailRequest ReplyTo { get; set; }

        /// <summary>
        /// Subject of your email.
        /// </summary>
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        /// <summary>
        /// Message content
        /// </summary>
        [Required(ErrorMessage = "E-mail content is required")]
        public string Content { get; set; }

        /// <summary>
        /// List of recipient's e-mail
        /// </summary>
        [Required(ErrorMessage = "To is required")]
        [EnsureMinimumElements(1, ErrorMessage = "At least one recipient must be informed")]
        public IEnumerable<EmailRequest> To { get; set; }

        /// <summary>
        /// List of cc e-mail recipient
        /// </summary>
        /// <example>typeof(EmailRequest)</example>
        public IEnumerable<EmailRequest> Cc { get; set; }

        /// <summary>
        /// List of bcc e-mail recipient
        /// </summary>
        public IEnumerable<EmailRequest> Bcc { get; set; }

        /// <summary>
        /// List of files to be sent as an attachment
        /// </summary>
        public IEnumerable<FileAttachmentRequest> Files { get; set; }

        /// <summary>
        /// Indicates whether the message will be sent in html format
        /// </summary>
        public bool EnableHtml { get; set; } = true;
    }

}
