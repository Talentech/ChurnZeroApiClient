using ChurnZeroApiClient.Common.Attributes;
using System.Reflection;

namespace ChurnZeroApiClient.Common.Helpers
{
    internal class AttributeHelpers
    {
        public static string GetQueryParamName<T>(string propertyName)
        {
            return typeof(T).GetProperty(propertyName)?.GetCustomAttribute<QueryParamNameAttribute>()?.Name;
        }
    }
}
