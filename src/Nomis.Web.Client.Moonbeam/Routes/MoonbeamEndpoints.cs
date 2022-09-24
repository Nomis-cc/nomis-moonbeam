using Nomis.Web.Client.Common.Routes;

namespace Nomis.Web.Client.Moonbeam.Routes
{
    /// <summary>
    /// Moonbeam endpoints.
    /// </summary>
    public class MoonbeamEndpoints :
        BaseEndpoints
    {
        /// <summary>
        /// Initialize <see cref="MoonbeamEndpoints"/>.
        /// </summary>
        /// <param name="baseUrl">Moonbeam API base URL.</param>
        public MoonbeamEndpoints(string baseUrl)
            : base(baseUrl)
        {
        }

        /// <inheritdoc/>
        public override string Blockchain => "moonbeam";
    }
}