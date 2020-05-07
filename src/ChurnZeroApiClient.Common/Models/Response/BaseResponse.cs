using System.Net;

namespace ChurnZeroApiClient.Models.Response
{
    public class BaseResponse
    {
        public HttpStatusCode Status { get; set; }
    }
}
