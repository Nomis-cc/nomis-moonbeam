namespace Nomis.Blockchain.Abstractions.Enums
{
    /// <summary>
    /// Blockchain network.
    /// </summary>
    [Flags]
    public enum BlockchainNetwork
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Ethereum.
        /// </summary>
        Ethereum = 1,

        /// <summary>
        /// Polygon.
        /// </summary>
        Polygon = 2,

        /// <summary>
        /// Solana.
        /// </summary>
        Solana = 4,

        /// <summary>
        /// BSC.
        /// </summary>
        BSC = 8
    }
}