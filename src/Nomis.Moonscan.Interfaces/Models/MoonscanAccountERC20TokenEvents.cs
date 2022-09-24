using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Nomis.Moonscan.Interfaces.Models
{
    /// <summary>
    /// Moonscan account ERC-20 token transfer events.
    /// </summary>
    public class MoonscanAccountERC20TokenEvents :
        IMoonscanTransferList<MoonscanAccountERC20TokenEvent>
    {
        /// <summary>
        /// Status.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// Account ERC-20 token event list.
        /// </summary>
        [JsonPropertyName("result")]
        [DataMember(EmitDefaultValue = true)]
        public List<MoonscanAccountERC20TokenEvent> Data { get; set; } = new();
    }
}