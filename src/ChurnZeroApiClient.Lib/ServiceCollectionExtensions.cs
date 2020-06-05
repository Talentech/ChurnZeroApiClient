using ChurnZeroApiClient.Settings;
using ChurnZeroApiClient.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nancy.TinyIoc;

namespace ChurnZeroApiClient
{
    public static class ServiceCollectionExtensions
    {
        public static string ChurnZeroSettingsSectionName { get; set; } = "ChurnZeroSettings";

        public static IServiceCollection AddChurnZeroApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions().Configure<ApiSettings>(configuration.GetSection(ChurnZeroSettingsSectionName));

            var apiSettings = new ApiSettings();
            configuration.GetSection(ChurnZeroSettingsSectionName).Bind(apiSettings);

            services.AddSingleton<IApiClientHandler>(new ApiClientHandler(apiSettings));
            services.AddScoped<IChurnZeroClient, ChurnZeroClient>();

            return services;
        }

        public static TinyIoCContainer AddChurnZeroApiClient(this TinyIoCContainer container, IConfiguration configuration)
        {
            var apiSettings = new ApiSettings();
            configuration.GetSection(ChurnZeroSettingsSectionName).Bind(apiSettings);

            container.Register<IApiClientHandler>(new ApiClientHandler(apiSettings));
            container.Register<IChurnZeroClient, ChurnZeroClient>();

            return container;
        }
    }
}
