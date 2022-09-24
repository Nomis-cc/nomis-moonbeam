using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Nomis.Blockchain.Abstractions.Settings;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nomis.Api.Common.Swagger.Filters
{
    /// <summary>
    /// Filter for hiding API from path in swagger documentation.
    /// </summary>
    public class HideMethodsFilter : IDocumentFilter
    {
        private readonly ApiVisibilitySettings _apiVisibilitySettings;

        /// <summary>
        /// Initialize <see cref="HideMethodsFilter"/>.
        /// </summary>
        /// <param name="apiVisibilitySettings"><see cref="ApiVisibilitySettings"/>.</param>
        public HideMethodsFilter(
            IOptions<ApiVisibilitySettings> apiVisibilitySettings)
        {
            _apiVisibilitySettings = apiVisibilitySettings.Value;
        }

        /// <inheritdoc/>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (!_apiVisibilitySettings.AeternityAPIEnabled)
            {
                SetVisibility(swaggerDoc, "aeternity");
            }

            if (!_apiVisibilitySettings.BobaAPIEnabled)
            {
                SetVisibility(swaggerDoc, "boba");
            }

            if (!_apiVisibilitySettings.BscAPIEnabled)
            {
                SetVisibility(swaggerDoc, "bsc");
            }

            if (!_apiVisibilitySettings.CeloAPIEnabled)
            {
                SetVisibility(swaggerDoc, "celo");
            }

            if (!_apiVisibilitySettings.CubeAPIEnabled)
            {
                SetVisibility(swaggerDoc, "cube");
            }

            if (!_apiVisibilitySettings.EthereumAPIEnabled)
            {
                SetVisibility(swaggerDoc, "ethereum");
            }

            if (!_apiVisibilitySettings.EvmosAPIEnabled)
            {
                SetVisibility(swaggerDoc, "evmos");
            }

            if (!_apiVisibilitySettings.MoonbeamAPIEnabled)
            {
                SetVisibility(swaggerDoc, "moonbeam");
            }

            if (!_apiVisibilitySettings.PolygonAPIEnabled)
            {
                SetVisibility(swaggerDoc, "polygon");
            }

            if (!_apiVisibilitySettings.RippleAPIEnabled)
            {
                SetVisibility(swaggerDoc, "ripple");
            }

            if (!_apiVisibilitySettings.SolanaAPIEnabled)
            {
                SetVisibility(swaggerDoc, "solana");
            }
        }

        private void SetVisibility(OpenApiDocument swaggerDoc, string name)
        {
            foreach (var path in swaggerDoc.Paths.Where(x =>
                         x.Key.StartsWith($"/api/v1/{name}", StringComparison.InvariantCultureIgnoreCase)))
            {
                swaggerDoc.Paths.Remove(path.Key);
            }

            var tag = swaggerDoc.Tags.FirstOrDefault(x =>
                x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (tag != null)
            {
                swaggerDoc.Tags.Remove(tag);
            }
        }
    }
}
