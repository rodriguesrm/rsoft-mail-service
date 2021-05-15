using Grpc.Core;
using RSoft.Mail.Web.Grpc.Contracts;
using System.Threading.Tasks;

namespace RSoft.Mail.Web.Grpc.Services
{
    public class SenderService : MailSender.MailSenderBase
    {

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="request">Request data</param>
        /// <param name="context">Server call context</param>
        public override Task<SendReply> Send(SendRequest request, ServerCallContext context)
        {
            return base.Send(request, context);
        }

    }
}
