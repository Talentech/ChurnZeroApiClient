using System;
using System.Net;

namespace ChurnZeroApiClient.Core
{
    public class ChurnZeroApiClientException : Exception
    {
        public string ResponseContent { get; }
        public HttpStatusCode? HttpStatusCode { get; }

        public ChurnZeroApiClientException()
        {
        }

        public ChurnZeroApiClientException(string message)
            : base(message)
        {
        }

        public ChurnZeroApiClientException(string message, string responseContent, HttpStatusCode httpStatusCode)
            : base(message)
        {
            ResponseContent = responseContent;
            HttpStatusCode = httpStatusCode;
        }

        public ChurnZeroApiClientException(string message, Exception innerException, HttpStatusCode httpStatusCode)
            : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ChurnZeroApiClientException(string message, Exception innerException, string responseContent)
            : base(message, innerException)
        {
            ResponseContent = responseContent;
        }
    }
}
