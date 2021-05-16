using Google.Protobuf.Collections;
using RSoft.Mail.Business.Models;
using RSoft.Mail.Web.Grpc.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RSoft.Mail.Web.Grpc.Extensions
{

    /// <summary>
    /// Provides extesion methods to map request/arguments
    /// </summary>
    public static class MapExtension
    {

        /// <summary>
        /// Map send-request to message
        /// </summary>
        /// <param name="request">Send request object</param>
        public static Message Map(this SendRequest request)
        {

            EmailAddress from = request.From.Map();
            EmailAddress replyTo = request.ReplyTo.Map();
            IEnumerable<EmailAddress> to = request.To.Map();
            IEnumerable<EmailAddress> cc = request.Cc?.Map() ?? null;
            IEnumerable<EmailAddress> bcc = request.Bcc?.Map() ?? null;
            IEnumerable<FileAttachment> files = request.Files?.Map() ?? null;

            Message message = new
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

        /// <summary>
        /// Map Types.Mail to EmailAddress
        /// </summary>
        /// <param name="source">Source object</param>
        public static EmailAddress Map(this SendRequest.Types.Email source)
        {
            if (source == null)
                return null;
            if (string.IsNullOrEmpty(source.Address))
                return null;
            return new EmailAddress(source.Address, source.Name);
        }

        /// <summary>
        /// Map Types.Mail list to EmailAddress list
        /// </summary>
        /// <param name="source">Source list</param>
        public static IEnumerable<EmailAddress> Map(this RepeatedField<SendRequest.Types.Email> source)
            => source.Select(item => item.Map()).ToList();

        /// <summary>
        /// Map Types.FileAttachment to FileAttachment dto
        /// </summary>
        /// <param name="source">Source object</param>
        public static FileAttachment Map(this SendRequest.Types.FileAttachment source)
            => new FileAttachment(source.Filename, source.Type, source.Content);

        /// <summary>
        /// map Types.FileAttachment list to FileAttachment dto list
        /// </summary>
        /// <param name="source">Source list</param>
        public static IEnumerable<FileAttachment> Map(this RepeatedField<SendRequest.Types.FileAttachment> source)
            => source.Select(item => item.Map()).ToList();

    }
}
