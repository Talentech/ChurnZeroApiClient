using ChurnZeroApiClient.Core.Extensions;

namespace ChurnZeroApiClient.Core.Helpers
{
    static class UrlHelper
    {
        internal static string CreateQueryWithParams<T>(string apiKey, T model)
        {
            return string.Empty.AddQueryParam(nameof(apiKey), apiKey).AddQueryParams(model);
        }
    }
}
