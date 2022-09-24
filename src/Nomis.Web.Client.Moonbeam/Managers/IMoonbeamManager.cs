using Nomis.Moonscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Nomis.Web.Client.Common.Managers;

namespace Nomis.Web.Client.Moonbeam.Managers
{
    /// <summary>
    /// Moonbeam manager.
    /// </summary>
    public interface IMoonbeamManager :
        IManager
    {
        /// <summary>
        /// Get moonbeam wallet score.
        /// </summary>
        /// <param name="address">Wallet address.</param>
        /// <returns>Returns result of <see cref="MoonbeamWalletScore"/>.</returns>
        Task<IResult<MoonbeamWalletScore>> GetWalletScoreAsync(string address);
    }
}