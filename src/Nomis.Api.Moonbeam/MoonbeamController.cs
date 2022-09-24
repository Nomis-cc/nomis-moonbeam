using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nomis.Api.Moonbeam.Abstractions;
using Nomis.Moonscan.Interfaces;
using Nomis.Moonscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Nomis.Api.Moonbeam
{
    /// <summary>
    /// A controller to aggregate all Moonbeam-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("Moonbeam.")]
    internal sealed partial class MoonbeamController :
        MoonbeamBaseController
    {
        private readonly ILogger<MoonbeamController> _logger;
        private readonly IMoonscanService _moonscanService;

        /// <summary>
        /// Initialize <see cref="MoonbeamController"/>.
        /// </summary>
        /// <param name="moonscanService"><see cref="IMoonscanService"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public MoonbeamController(
            IMoonscanService moonscanService,
            ILogger<MoonbeamController> logger)
        {
            _moonscanService = moonscanService ?? throw new ArgumentNullException(nameof(moonscanService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get Nomis Score for given wallet address.
        /// </summary>
        /// <param name="address" example="0xBb8421f2e9DC8b503711F70e051E19EA4b30F5Cb">Moonbeam wallet address to get Nomis Score.</param>
        /// <returns>An NomisScore value and corresponding statistical data.</returns>
        /// <remarks>
        /// Sample request:
        ///     GET /api/v1/moonbeam/wallet/0xBb8421f2e9DC8b503711F70e051E19EA4b30F5Cb/score
        /// </remarks>
        /// <response code="200">Returns Nomis Score and stats.</response>
        /// <response code="400">Address not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("wallet/{address}/score", Name = "GetMoonbeamWalletScore")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetMoonbeamWalletScore",
            Tags = new[] { MoonbeamTag })]
        [ProducesResponseType(typeof(Result<MoonbeamWalletScore>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetMoonbeamWalletScoreAsync(
            [Required(ErrorMessage = "Wallet address should be set")] string address)
        {
            var result = await _moonscanService.GetWalletStatsAsync(address);
            return Ok(result);
        }
    }
}