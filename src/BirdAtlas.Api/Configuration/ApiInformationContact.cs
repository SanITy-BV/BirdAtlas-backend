namespace BirdAtlas.Api.Configuration
{
    /// <summary>
    /// Contact information for API owners and creators
    /// </summary>
    public class ApiInformationContact
    {
        /// <summary>
        /// Contact name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contact emails
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Is this the primary contact for the API?
        /// Only the (first) primary contact is shown on OpenApi.
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Twitter handle
        /// </summary>
        public string Twitter { get; set; }
    }
}