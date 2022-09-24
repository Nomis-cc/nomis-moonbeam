using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Nomis.Moonscan.Interfaces.Models
{
    /// <summary>
    /// Moonscan transfer list.
    /// </summary>
    /// <typeparam name="TListItem">Moonscan transfer.</typeparam>
    public interface IMoonscanTransferList<TListItem>
        where TListItem : IMoonscanTransfer
    {
        /// <summary>
        /// List of transfers.
        /// </summary>
        [JsonPropertyName("result")]
        [DataMember(EmitDefaultValue = true)]
        public List<TListItem> Data { get; set; }
    }
}