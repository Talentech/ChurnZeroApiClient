using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ChurnZeroApiClient.Lib")]
[assembly: InternalsVisibleTo("ChurnZeroApiClient.Core")]
namespace ChurnZeroApiClient.Common.Settings
{
    internal class ApiSettings
    {
        /// <summary>
        /// If you are located in Europe/Asia call https://eu1analytics.churnzero.net/i
        /// If not call https://analytics.churnzero.net/i
        /// </summary>
        public Uri ApiBaseUrl { get; set; }

        /// <summary>
        /// Every request must include your appKey which can be found on the Admin > AppKey Page.
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// The AccountExternalID is your unique record to identify your account. This ID should be in your CRM.
        /// </summary>
        public string AccountExternalId { get; set; }

        /// <summary>
        /// The contactExternalId must be unique within the account. 
        /// This could be a email address, a unique record that is also contained in your CRM, or the ID of the contact record of your CRM.
        /// </summary>
        public string ContactExternalId { get; set; }
    }
}
