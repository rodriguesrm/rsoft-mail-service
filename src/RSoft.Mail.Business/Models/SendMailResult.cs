using System.Collections.Generic;

namespace RSoft.Mail.Business.Models
{

    /// <summary>
    /// Send mail model result
    /// </summary>
    public class SendMailResult
    {

        #region Constructors

        /// <summary>
        /// Create a new send-mail-result object instance
        /// </summary>
        /// <param name="success">Indicates whether the operation was successful</param>
        /// <param name="errors">List of errors</param>
        public SendMailResult(bool success, IEnumerable<KeyValuePair<string, string>> errors)
        {
            Success = success;
            Errors = errors;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the operation was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// List of errors
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }

        #endregion

    }
}
