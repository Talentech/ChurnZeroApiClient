namespace ChurnZeroApiClient.Models.Request
{
    public class TrackEventRequest : BaseRequest, IActionRequest
    {
        public string ActionName => "trackEvent";

        /// <summary>
        /// (required)- This is the unique name of the event (i.e Sent Blog Post). 
        /// If the Event Name is not found it will be created.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// (optional)- A description of the Event (i.e Blog Title)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// (optional)- The number related to this event (Commonly used to track things like email sent, etc)
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///  (optional)-Additional custom fields in a name/value pair. 
        ///  Important Note: At this time, custom fields cannot be created on the fly. 
        ///  Please make sure to request any required custom field(s) before attempting to send any data. 
        ///  Requests can be made through your ChurnZero Implementation Specialist or by reaching out to support@churnzero.net.
        /// </summary>
        public object Customfields { get; set; }
    }
}
