using ChurnZeroApiClient.Settings;
using ChurnZeroApiClient.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChurnZeroApiClient
{
    public static class ServiceCollectionExtensions
    {
        public static string ChurnZeroSettingsSectionName { get; set; } = "ChurnZeroSettings";

        public static IServiceCollection AddChurnZeroApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions().Configure<ApiSettings>(configuration.GetSection(ChurnZeroSettingsSectionName));

            services.AddScoped<IApiClientHandler, ApiClientHandler>();
            services.AddScoped<IChurnZeroClient, ChurnZeroClient>();

            return services;
        }
    }
}
