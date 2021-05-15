using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using RSoft.Mail.Web.Grpc.Services;

namespace RSoft.Mail.Web.Grpc.Extensions
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
