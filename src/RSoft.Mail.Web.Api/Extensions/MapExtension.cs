using RSoft.Mail.Business.Models;
using RSoft.Mail.Web.Api.Model.Request.v1_0;
using System.Collections.Generic;
using System.Linq;

namespace RSoft.Mail.Web.Api.Extensions
{

    /// <summary>
    /// Provides extesion methods to map request/arguments
    /// </summary>
    public static class MapExtension
    {

        /// <summary>
        /// Map e-mail request to e-mail address object
        /// </summary>
        /// <param name="request">E-mail request object</param>
        public static EmailAddress Map(this EmailRequest request)
            => new EmailAddress(request.Email, request.Name);

        /// <summary>
        /// Map list of e-mail request to list of e-mail address object
        /// </summary>
        /// <param name="list">List of E-mail request object</param>
        public static IEnumerable<EmailAddress> Map(this IEnumerable<EmailRequest> list)
            => list.Select(s => s.Map()).ToList();

        /// <summary>
        /// Map file-attachment-request to file-attachement
        /// </summary>
        /// <param name="request">File attachement request object</param>
        public static FileAttachment Map(this FileAttachmentRequest request)
            => new FileAttachment(request.Filename, request.Type, request.Content);

        /// <summary>
        /// Map list of file-attachment-request to list of file-attachement
        /// </summary>
        /// <param name="list">List of File attachement request object</param>
        public static IEnumerable<FileAttachment> Map(this IEnumerable<FileAttachmentRequest> list)
            => list.Select(f => f.Map()).ToList();

        /// <summary>
        /// Map send-request to message
        /// </summary>
        /// <param name="request">Send request object</param>
        public static Message Map(this SendRequest request)
        {

            EmailAddress from = request.From.Map();
            EmailAddress replyTo = request.ReplyTo?.Map() ?? null;
            IEnumerable<EmailAddress> to = request.To.Map();
            IEnumerable<EmailAddress> cc = request.Cc?.Map() ?? null;
            IEnumerable<EmailAddress> bcc = request.Bcc?.Map() ?? null;
            IEnumerable<FileAttachment> files = request.Files?.Map() ?? null;

            Message message = new Message
            (
                request.Subject,
                request.Content,
                from,
                replyTo,
                to,
                cc,
                bcc,
                files,
                request.EnableHtml
            );

            return message;

        }

    }
}
