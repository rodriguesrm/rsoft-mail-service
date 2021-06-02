using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace RSoft.Mail.Web.Grpc.Host.Extensions
{

    /// <summary>
    /// Grpc host extension options/methods
    /// </summary>
    public static class GrpcHostExtension
    {

        /// <summary>
        /// Map gRpc services endpoints
        /// </summary>
        /// <param name="endpoints">Endpoints builder object</param>
        public static IEndpointRouteBuilder MapServices(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<SenderService>();
            return endpoints;
        }

    }
}
