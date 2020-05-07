using ChurnZeroApiClient.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Web;

namespace ChurnZeroApiClient.Core.Extensions
{
    static class ApiClientExtensions
    {
        internal static string AddQueryParam(this string uri, string key, object value)
        {
            key = HttpUtility.UrlEncode(key);

            if (value is List<string>)
            {
                foreach (var element in value as List<string>)
                {
                    uri += GetDelimForUriParam(uri) + $"{key}={HttpUtility.UrlEncode(element)}";
                }

                return uri;
            }
            else if (value.GetType().IsArray)
            {
                foreach (var element in value as Array)
                {
                    uri += GetDelimForUriParam(uri) + $"{key}={HttpUtility.UrlEncode(element.ToString())}";
                }

                return uri;
            }
            else
            {
                return uri + GetDelimForUriParam(uri) + $"{key}={HttpUtility.UrlEncode(value.ToString())}";
            }
        }

        internal static string AddQueryParams<T>(this string uri, string propName, IList<T> propValues)
        {
            foreach (var value in propValues)
            {
                uri = uri.AddQueryParam(propName, value);
            }

            return uri;
        }

        internal static string AddQueryParams<T>(this string uri, T model)
        {
            foreach (var prop in model.GetType().GetProperties())
            {
                var value = prop.GetValue(model);
                var queryParamName = AttributeHelpers.GetQueryParamName<T>(prop.Name);
                if (value != null)
                {
                    uri = uri.AddQueryParam(queryParamName, value);
                }
            }

            return uri;
        }

        private static string GetDelimForUriParam(string uri)
        {
            if ((uri == null) || !uri.Contains("?"))
                return "?";
            else if (uri.EndsWith("?") || uri.EndsWith("&"))
                return string.Empty;
            else
                return "&";
        }
    }
}