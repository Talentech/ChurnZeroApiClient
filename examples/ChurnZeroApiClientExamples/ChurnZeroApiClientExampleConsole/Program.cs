using ChurnZeroApiClient;
using ChurnZeroApiClient.Models.Request;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ChurnZeroApiClientExampleConsole
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Console.WriteLine("ChurnZero TrackEvent - Call");

            var trackEventResponse = await serviceProvider.GetService<IChurnZeroClient>().TrackEventAsync(new TrackEventRequest
            {
                AccountExternalId = "test",
                ContactExternalId = "test@test.com",
                EventName = "sample-event-test"
            });

            Console.WriteLine("ChurnZero TrackEvent - Done");
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton(configuration);

            serviceCollection.AddChurnZeroApiClient(configuration);
        }
    }
}
