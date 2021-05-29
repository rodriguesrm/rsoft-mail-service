using RSoft.Mail.Business.Enums;
using RSoft.Mail.Business.Models;
using RSoft.Mail.Contract;
using System.Threading;
using System.Threading.Tasks;

namespace RSoft.Mail.Business.Contracts
{

    /// <summary>
    /// Mail sender interface
    /// </summary>
    public interface ISender
    {

        /// <summary>
        /// Send e-mail
        /// </summary>
        /// <param name="message">Message details</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        Task<SendMailResult> SendMailAsync(IMessage message, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get sender type
        /// </summary>
        SenderType SenderType { get; }

    }

}
