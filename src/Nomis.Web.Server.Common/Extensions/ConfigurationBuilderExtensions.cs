using Nomis.Blockchain.Abstractions.Settings;
using Nomis.Moonscan.Interfaces.Settings;

namespace Nomis.Web.Server.Common.Extensions
{
    /// <summary>
    /// <see cref="IConfigurationBuilder"/> extension methods.
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
        private const string ConfigsDirectory = "Configs";

        /// <summary>
        /// Add configuration from json.
        /// </summary>
        /// <param name="manager"><see cref="IConfigurationBuilder"/>.</param>
        /// <returns>Returns <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddJsonConfigs(this IConfigurationBuilder manager)
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            return manager
                .AddJsonFile(Path.Combine(ConfigsDirectory, $"{nameof(ApiVisibilitySettings).ToLower()}.json"), false, true)
                .AddJsonFile(Path.Combine(ConfigsDirectory, $"{nameof(ApiVisibilitySettings).ToLower()}.{env}.json"), true, true)
                .AddJsonFile(Path.Combine(ConfigsDirectory, $"{nameof(MoonscanSettings).ToLower()}.json"), false, true)
                .AddJsonFile(Path.Combine(ConfigsDirectory, $"{nameof(MoonscanSettings).ToLower()}.{env}.json"), true, true);
        }
    }
}