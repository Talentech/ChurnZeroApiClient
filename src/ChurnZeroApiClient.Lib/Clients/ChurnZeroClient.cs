using ChurnZeroApiClient.Core;
using ChurnZeroApiClient.Models.Request;
using System.Threading.Tasks;

namespace ChurnZeroApiClient
{
    internal class ChurnZeroClient : ChurnZeroClientBase, IChurnZeroClient
    {
        public ChurnZeroClient(IApiClientHandler apiClientHandler) : base(apiClientHandler) { }

        public async Task<dynamic> TrackEventAsync(TrackEventRequest model)
        {
            return await _apiClientHandler.Get<dynamic, TrackEventRequest>(model);
        }

        public async Task<dynamic> SetAttributeAsync(SetAttributeRequest model)
        {
            return await _apiClientHandler.Get<dynamic, SetAttributeRequest>(model);
        }

        public async Task<dynamic> IncrementAttributeAsync(IncrementAttributeRequest model)
        {
            return await _apiClientHandler.Get<dynamic, IncrementAttributeRequest>(model);
        }
    }
}
