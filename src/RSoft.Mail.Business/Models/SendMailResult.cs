using System;
using System.Collections.Generic;
using System.Text;

namespace RSoft.Mail.Business.Models
{
    
    /// <summary>
    /// Send mail model result
    /// </summary>
    public class SendMailResult
    {

        /// <summary>
        /// Indicates whether the operation was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Erro's list
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }

    }
}
