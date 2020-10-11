namespace RSoft.Mail.Business.Models.SendGrid
{

    /// <summary>
    /// SendGrid sending error detail model
    /// </summary>
    public class SendGridErrorDetail
    {

        /// <summary>
        /// Field name
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Help information
        /// </summary>
        public string Help { get; set; }

    }

}
