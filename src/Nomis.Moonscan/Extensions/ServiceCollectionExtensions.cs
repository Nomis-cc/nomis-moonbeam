using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nomis.Blockchain.Abstractions.Settings;
using Nomis.Moonscan.Interfaces;
using Nomis.Moonscan.Interfaces.Settings;
using Nomis.Utils.Extensions;

namespace Nomis.Moonscan.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Moonscan service.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddMoonscanService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSettings<MoonscanSettings>(configuration);
            var settings = configuration.GetSettings<ApiVisibilitySettings>();
            if (settings.MoonbeamAPIEnabled)
            {
                return services
                    .AddTransient<IMoonscanClient, MoonscanClient>()
                    .AddTransientInfrastructureService<IMoonscanService, MoonscanService>();
            }
            else
            {
                return services;
            }
        }
    }
}