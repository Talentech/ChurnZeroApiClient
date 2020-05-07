namespace ChurnZeroApiClient.Models.Request
{
    public class IncrementAttributeRequest : BaseRequest, IActionRequest
    {
        public string ActionName => "incrementAttribute";

        /// <summary>
        /// (Required)- Can be either 'contact' or 'account'
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        /// (Required)- Name of the field to be updated
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Required)- Value to add to current value (can be positive or negative).
        /// </summary>
        public int Value { get; set; }
    }
}
