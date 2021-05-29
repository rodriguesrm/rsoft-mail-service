using Microsoft.Extensions.Logging;
using RSoft.Mail.Business.Contracts;
using RSoft.Mail.Business.Models;
using RSoft.Mail.Contract;
using RSoft.Mail.Web.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSoft.Mail.Web.Grpc.ConsoleTest
{
    
    public class Program
    {
        public static Task Main(string[] args)
        {

            IGrpcMailServiceProvider provider = new GrpcMailServiceProvider();
            string token = "";

            IEmailAddress from = new EmailAddress("rodrigo.rodrigues.tech@gmail.com", "RSoft Fetch");
            IEmailAddress replyTo = from;
            IEnumerable<IEmailAddress> to = new List<IEmailAddress>() { new EmailAddress("rodrigo.rodrigues9@fatec.sp.gov.br", "Rodrigo Fatec") };
            IEnumerable<IEmailAddress> cc = new List<IEmailAddress>();
            IEnumerable<IEmailAddress> bcc = new List<IEmailAddress>();
            IEnumerable<IFileAttachment> files = new List<FileAttachment>();
            bool enableHtml = true;

            string content = "Este é um <strong>teste</strong> de envio de e-mail via serviço gRpc";

            IMessageHandle message = new Message("Send-Mail by Console Test", content, from, replyTo, to, cc, bcc, files, enableHtml);
            var reply = provider.SendMail(message, "https://127.0.0.1:5001", token, "rodriguesrm@gmail.com").Result;

            Console.WriteLine($"Status: {(reply.Success ? "Success" : "FAIL")}");
            Console.WriteLine($"Message: {(reply.Success ? $"id=>{reply.MailId}" : reply.Errors)}");

            Console.ReadKey();

            return Task.CompletedTask;
        }
    }
}
