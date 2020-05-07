using ChurnZeroApiClient.Core;
using ChurnZeroApiClient.Core.Extensions;
using ChurnZeroApiClient.Settings;
using Microsoft.Extensions.Options;

namespace ChurnZeroApiClient
{
    internal abstract class ChurnZeroClientBase
    {
        public readonly IApiClientHandler _apiClientHandler;
        public readonly IOptions<ApiSettings> _apiSettings;

        public ChurnZeroClientBase(IOptions<ApiSettings> apiSettings, IApiClientHandler apiClientHandler)
        {
            _apiSettings = apiSettings;
            _apiClientHandler = apiClientHandler;
        }

        internal string CreateQueryWithApiKeyAndModelParams<T>(T model)
        {
            var appKey = _apiSettings.Value.AppKey;
            return string.Empty.AddQueryParam(nameof(appKey), appKey).AddQueryParams(model);
        }
    }
}
