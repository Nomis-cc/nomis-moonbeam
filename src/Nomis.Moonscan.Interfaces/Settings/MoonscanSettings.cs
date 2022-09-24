using Nomis.Utils.Contracts.Common;

namespace Nomis.Moonscan.Interfaces.Settings
{
    /// <summary>
    /// Moonscan settings.
    /// </summary>
    public class MoonscanSettings :
        ISettings
    {
        /// <summary>
        /// API key for moonscan.
        /// </summary>
        /// <remarks>
        /// <see href="https://moonbeam.moonscan.io/apis"/>
        /// </remarks>
        public string? ApiKey { get; set; }

        /// <summary>
        /// API base URL.
        /// </summary>
        /// <remarks>
        /// <see href="https://moonbeam.moonscan.io/apis#accounts"/>
        /// </remarks>
        public string? ApiBaseUrl { get; set; }
    }
}