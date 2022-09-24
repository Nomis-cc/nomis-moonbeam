namespace Nomis.Moonscan.Interfaces.Models
{
    /// <summary>
    /// Moonbeam wallet score.
    /// </summary>
    public class MoonbeamWalletScore
    {
        /// <summary>
        /// Nomis Score in range of [0; 1].
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Additional stat data used in score calculations.
        /// </summary>
        public MoonbeamWalletStats? Stats { get; set; }
    }
}