using Microsoft.Extensions.DependencyInjection;

namespace RSoft.Mail.Web.Grpc.Client.Extensions
{

    /// <summary>
    /// Dependency injection static class
    /// </summary>
    public static class DependencyInjection
    {

        /// <summary>
        /// Register service for RSoft Grpc Client
        /// </summary>
        /// <param name="service">Service collection</param>
        public static IServiceCollection MailGrpcServiceClientRegister(this IServiceCollection service)
        {
            service.AddScoped<IGrpcMailServiceProvider, GrpcMailServiceProvider>();
            return service;
        }

    }
}
