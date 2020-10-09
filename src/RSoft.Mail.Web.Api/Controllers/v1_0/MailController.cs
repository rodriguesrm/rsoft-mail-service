using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSoft.Framework.Web.Api;
using RSoft.Framework.Web.Model.Response;
using RSoft.Logs.Model;
using RSoft.Mail.Business.Services;
using RSoft.Mail.Web.Api.Model.Request.v1_0;

namespace RSoft.Mail.Web.Api.Controllers.v1_0
{

    /// <summary>
    /// API Mail Service
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MailController : ApiBaseController
    {

        #region Local objects/variables

        private readonly IMailService _mailService;

        #endregion


        #region Constructors

        /// <summary>
        /// Create a new API Controller instance
        /// </summary>
        /// <param name="mailService">Mail service</param>
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        #endregion

        #region Local methods

        /// <summary>
        /// Performa a send mail
        /// </summary>
        /// <param name="request">Request data</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        private Task<IActionResult> RunSendAsync(SendRequest request, CancellationToken cancellationToken = default)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.err)

            //string redirect = HttpContext.Request.Query["redirect"];
            //var _mailService
            throw new NotImplementedException();
        }

        #endregion

        #region Actions/Endpoints

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">Request data</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete</param>
        /// <response code="200">Successful request processing</response>
        /// <response code="400">Invalid request, see details in response</response>
        /// <response code="401">Authentication Failed / Access Denied</response>
        /// <response code="500">Request processing failed</response>
        [ProducesResponseType(typeof(IEnumerable<Guid>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<GenericNotificationResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(GerericExceptionResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Send([FromBody] SendRequest request, CancellationToken cancellationToken = default)
            => await RunActionAsync(RunSendAsync(request, cancellationToken), true, cancellationToken);

        #endregion

    }

}
