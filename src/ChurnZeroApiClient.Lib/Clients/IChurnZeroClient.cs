using ChurnZeroApiClient.Models.Request;
using System.Threading.Tasks;

namespace ChurnZeroApiClient
{
    public interface IChurnZeroClient
    {
        /// <summary>
        ///  Track an event
        /// </summary>
        /// <param name="model">TrackEventRequest</param>
        /// <returns>dynamic json</returns>
        Task<dynamic> TrackEventAsync(TrackEventRequest model);

        /// <summary>
        ///  Set Attribute on Account or Contact
        ///  Attributes about the account or features can be tracked in ChurnZero by using the setAttribute method. 
        ///  Attributes can be set one at a time or in batch via a document.
        /// </summary>
        /// <param name="model">SetAttributeRequest</param>
        /// <returns>dynamic json</returns>
        Task<dynamic> SetAttributeAsync(SetAttributeRequest model);

        /// <summary>
        ///  Increment Attribute on Account or Contact
        ///  Numeric attribues can be incremented via the incrementAttriubute Method. 
        ///  Like the setAttribute method, numeric values can be incremented one at a time or batch via a document.
        /// </summary>
        /// <param name="model">IncrementAttributeRequest</param>
        /// <returns>dynamic json</returns>
        Task<dynamic> IncrementAttributeAsync(IncrementAttributeRequest model);
    }
}