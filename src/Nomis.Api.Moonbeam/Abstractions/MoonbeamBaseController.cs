using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nomis.Api.Common.Abstractions;
using Nomis.Api.Common.Swagger.Examples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Nomis.Api.Moonbeam.Abstractions
{
    /// <summary>
    /// Base controller for Moonbeam.
    /// </summary>
    [ApiController]
    [Route(BasePath + "/[controller]")]
    public abstract class MoonbeamBaseController :
        BaseController
    {
        /// <summary>
        /// Base path for routing.
        /// </summary>
        protected internal new const string BasePath = "api/v{version:apiVersion}/moonbeam";

        /// <summary>
        /// Common tag for Moonbeam actions.
        /// </summary>
        protected internal const string MoonbeamTag = "Moonbeam";
    }

    /// <summary>
    /// A controller to aggregate all Moonbeam-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("Moonbeam.")]
    internal sealed partial class MoonbeamController :
        MoonbeamBaseController
    {
        /// <summary>
        /// Ping API.
        /// </summary>
        /// <remarks>
        /// For health checks.
        /// </remarks>
        /// <returns>Return "Ok" string.</returns>
        /// <response code="200">Returns "Ok" string.</response>
        [HttpGet(nameof(Ping))]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = nameof(Ping),
            Tags = new[] { MoonbeamTag })]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PingResponseExample))]
        public IActionResult Ping()
        {
            return Ok("Ok");
        }
    }
}