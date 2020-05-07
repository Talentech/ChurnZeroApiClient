namespace ChurnZeroApiClient.Models.Request
{
    public class SetAttributeRequest : BaseRequest, IActionRequest
    {
        public string ActionName => "setAttribute";

        /// <summary>
        /// (Required)- Can be either 'contact' or 'account'
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        /// (Required)- Name of the field to be updated
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required)- New value of attibute.
        /// </summary>
        public int Value { get; set; }
    }
}
