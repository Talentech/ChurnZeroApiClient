using ChurnZeroApiClient.Core;

namespace ChurnZeroApiClient
{
    internal abstract class ChurnZeroClientBase
    {
        public readonly IApiClientHandler _apiClientHandler;

        public ChurnZeroClientBase(IApiClientHandler apiClientHandler)
        {
            _apiClientHandler = apiClientHandler;
        }
    }
}
