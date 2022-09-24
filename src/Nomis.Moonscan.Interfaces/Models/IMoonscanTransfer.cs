using System.Text.Json.Serialization;

namespace Nomis.Moonscan.Interfaces.Models
{
    /// <summary>
    /// Moonscan transfer.
    /// </summary>
    public interface IMoonscanTransfer
    {
        /// <summary>
        /// Block number.
        /// </summary>
        [JsonPropertyName("blockNumber")]
        public string? BlockNumber { get; set; }
    }
}