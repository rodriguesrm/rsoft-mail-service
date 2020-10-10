using RSoft.Mail.Web.Api.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RSoft.Mail.Web.Api.Model.Request.v1_0
{

    /// <summary>
    /// File attachment model request
    /// </summary>
    public class FileAttachmentRequest
    {

        /// <summary>
        /// Gets the filename of the attachment.
        /// </summary>
        [Required(ErrorMessage = "Filename is required")]
        public string Filename { get; set; }

        /// <summary>
        /// Gets the mime type of the content you are attaching. For example, application/pdf
        /// </summary>
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        /// <summary>
        /// Gets the Base64 encoded content of the attachment.
        /// </summary>
        [Required(ErrorMessage = "File content is required")]
        [Base64(ErrorMessage = "The file content is not a valid base64")]
        public string Content { get; set; }

    }
}
