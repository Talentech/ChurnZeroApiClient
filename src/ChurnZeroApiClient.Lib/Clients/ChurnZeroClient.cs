using ChurnZeroApiClient.Core;
using ChurnZeroApiClient.Models.Request;
using ChurnZeroApiClient.Settings;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ChurnZeroApiClient
{
    internal class ChurnZeroClient : ChurnZeroClientBase, IChurnZeroClient
    {
        public ChurnZeroClient(IOptions<ApiSettings> apiSettings, IApiClientHandler apiClientHandler)
            : base(apiSettings, apiClientHandler) { }

        public async Task<dynamic> TrackEventAsync(TrackEventRequest model)
        {
            return await _apiClientHandler.Get<dynamic>(CreateQueryWithApiKeyAndModelParams(model));
        }

        public async Task<dynamic> SetAttributeAsync(SetAttributeRequest model)
        {
            return await _apiClientHandler.Get<dynamic>(CreateQueryWithApiKeyAndModelParams(model));
        }

        public async Task<dynamic> IncrementAttributeAsync(IncrementAttributeRequest model)
        {
            return await _apiClientHandler.Get<dynamic>(CreateQueryWithApiKeyAndModelParams(model));
        }
    }
}
