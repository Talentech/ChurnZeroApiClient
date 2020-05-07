using ChurnZeroApiClient.Core.Extensions;

namespace ChurnZeroApiClient.Core.Helpers
{
    static class UrlHelper
    {
        internal static string CreateQueryWithParams<T>(T model)
        {
            return string.Empty.AddQueryParams(model);
        }
    }
}
