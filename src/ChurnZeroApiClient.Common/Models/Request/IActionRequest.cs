namespace ChurnZeroApiClient.Models.Request
{
    public interface IActionRequest
    {
        /// <summary>
        /// Action name from API
        /// </summary>
        string ActionName { get; }
    }
}
