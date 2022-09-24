using Microsoft.Extensions.Options;
using Nomis.Moonscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Nomis.Web.Client.Common.Extensions;
using Nomis.Web.Client.Common.Settings;
using Nomis.Web.Client.Moonbeam.Routes;

namespace Nomis.Web.Client.Moonbeam.Managers
{
    /// <inheritdoc cref="IMoonbeamManager" />
    public class MoonbeamManager :
        IMoonbeamManager
    {
        private readonly HttpClient _httpClient;
        private readonly MoonbeamEndpoints _endpoints;

        /// <summary>
        /// Initialize <see cref="MoonbeamManager"/>.
        /// </summary>
        /// <param name="webApiSettings"><see cref="WebApiSettings"/>.</param>
        public MoonbeamManager(
            IOptions<WebApiSettings> webApiSettings)
        {
            _httpClient = new()
            {
                BaseAddress = new(webApiSettings.Value?.ApiBaseUrl ?? throw new ArgumentNullException(nameof(webApiSettings.Value.ApiBaseUrl)))
            };
            _endpoints = new(webApiSettings.Value?.ApiBaseUrl ?? throw new ArgumentNullException(nameof(webApiSettings.Value.ApiBaseUrl)));
        }

        /// <inheritdoc />
        public async Task<IResult<MoonbeamWalletScore>> GetWalletScoreAsync(string address)
        {
            var response = await _httpClient.GetAsync(_endpoints.GetWalletScore(address));
            return await response.ToResultAsync<MoonbeamWalletScore>();
        }
    }
}