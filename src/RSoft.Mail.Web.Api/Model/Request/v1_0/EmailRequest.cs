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
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail address is invalid")]
        //[Required(ErrorMessage = "E-mail address is required")]
        public string Email { get; }
        //BUG: ***** PAREI AQUI ***** => E-mail validation not working

        /// <summary>
        /// Sender or recipient name
        /// </summary>
        public string Name { get; }

    }
}
