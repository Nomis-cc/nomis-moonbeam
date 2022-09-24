using Nomis.Moonscan.Interfaces.Models;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.Moonscan.Interfaces
{
    /// <summary>
    /// Moonscan service.
    /// </summary>
    public interface IMoonscanService :
        IInfrastructureService
    {
        /// <summary>
        /// Client for interacting with Moonscan API.
        /// </summary>
        public IMoonscanClient Client { get; }

        /// <summary>
        /// Get moonbeam wallet stats by address.
        /// </summary>
        /// <param name="address">Moonbeam wallet address.</param>
        /// <returns>Returns <see cref="MoonbeamWalletScore"/> result.</returns>
        public Task<Result<MoonbeamWalletScore>> GetWalletStatsAsync(string address);
    }
}