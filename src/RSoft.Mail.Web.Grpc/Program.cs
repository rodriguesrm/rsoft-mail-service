using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RSoft.Logs.Extensions;
using MsHost = Microsoft.Extensions.Hosting.Host;

namespace RSoft.Mail.Web.Grpc.Host
{

    /// <summary>
    /// Create host and run application
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Main method to run application
        /// </summary>
        /// <param name="args">Arguments array</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Build host application
        /// </summary>
        /// <param name="args">Arguments array</param>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            MsHost.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsoleLogger();
                    logging.AddSeqLogger();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
