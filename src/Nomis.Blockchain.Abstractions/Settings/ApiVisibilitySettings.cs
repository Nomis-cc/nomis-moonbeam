using Nomis.Utils.Contracts.Common;

namespace Nomis.Blockchain.Abstractions.Settings
{
    /// <summary>
    /// API visibility settings.
    /// </summary>
    public class ApiVisibilitySettings
        : ISettings
    {
        /// <summary>
        /// Aeternity API is enabled.
        /// </summary>
        public bool AeternityAPIEnabled { get; set; }

        /// <summary>
        /// Boba API is enabled.
        /// </summary>
        public bool BobaAPIEnabled { get; set; }

        /// <summary>
        /// BSC API is enabled.
        /// </summary>
        public bool BscAPIEnabled { get; set; }

        /// <summary>
        /// Celo API is enabled.
        /// </summary>
        public bool CeloAPIEnabled { get; set; }

        /// <summary>
        /// Cube API is enabled.
        /// </summary>
        public bool CubeAPIEnabled { get; set; }

        /// <summary>
        /// Ethereum API is enabled.
        /// </summary>
        public bool EthereumAPIEnabled { get; set; }

        /// <summary>
        /// Evmos API is enabled.
        /// </summary>
        public bool EvmosAPIEnabled { get; set; }

        /// <summary>
        /// Moonbeam API is enabled.
        /// </summary>
        public bool MoonbeamAPIEnabled { get; set; }

        /// <summary>
        /// Polygon API is enabled.
        /// </summary>
        public bool PolygonAPIEnabled { get; set; }

        /// <summary>
        /// Ripple API is enabled.
        /// </summary>
        public bool RippleAPIEnabled { get; set; }

        /// <summary>
        /// Solana API is enabled.
        /// </summary>
        public bool SolanaAPIEnabled { get; set; }
    }
}