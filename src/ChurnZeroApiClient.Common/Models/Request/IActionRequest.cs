using ChurnZeroApiClient.Common.Attributes;

namespace ChurnZeroApiClient.Models.Request
{
    public interface IActionRequest
    {
        /// <summary>
        /// Action name from API
        /// </summary>
        [QueryParamName("action")]
        string ActionName { get; }
    }
}
