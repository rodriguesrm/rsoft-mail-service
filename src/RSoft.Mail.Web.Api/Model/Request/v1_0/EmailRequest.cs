using System.ComponentModel.DataAnnotations;

namespace RSoft.Mail.Web.Api.Model.Request.v1_0
{

    /// <summary>
    /// E-mail request model
    /// </summary>
    public class EmailRequest
    {

        /// <summary>
        /// E-mail address
        /// </summary>
        [Required(ErrorMessage = "E-mail address is required")]
        [EmailAddress(ErrorMessage = "E-mail address is invalid")]
        public string Email { get; set; }

        /// <summary>
        /// Sender or recipient name
        /// </summary>
        public string Name { get; set; }

    }
}
