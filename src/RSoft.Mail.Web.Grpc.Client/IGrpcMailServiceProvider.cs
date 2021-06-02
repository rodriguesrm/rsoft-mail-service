using RSoft.Mail.Web.Grpc.Contracts;
using System.Threading.Tasks;
using IRSoftMessage = RSoft.Mail.Contract.IMessage;

namespace RSoft.Mail.Web.Grpc.Client
{
    
    /// <summary>
    /// RSoft gRpc Mail Service provider interface/contract
    /// </summary>
    public interface IGrpcMailServiceProvider
    {

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="message">Message data</param>
        /// <param name="urlService">Mail service url</param>
        /// <param name="token">Token authentication</param>
        /// <param name="redirectTo">E-mail to redirect (use for developer/stage/testing environment)</param>
        Task<MailSendReply> SendMail(IRSoftMessage message, string urlService, string token = null, string redirectTo = null);

    }

}
