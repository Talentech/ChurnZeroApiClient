using ChurnZeroApiClient.Common.Attributes;

namespace ChurnZeroApiClient.Models.Request
{
    public class SetAttributeRequest : BaseRequest, IActionRequest
    {
        public string ActionName => "setAttribute";

        /// <summary>
        /// (Required)- Can be either 'contact' or 'account'
        /// </summary>
        [QueryParamName("entity")]
        public string Entity { get; set; }

        /// <summary>
        /// (Required)- Name of the field to be updated
        /// </summary>
        [QueryParamName("name")]
        public string Name { get; set; }

        /// <summary>
        /// (Required)- New value of attibute.
        /// </summary>
        [QueryParamName("value")]
        public int Value { get; set; }
    }
}
