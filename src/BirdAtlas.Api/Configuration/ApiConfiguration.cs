﻿using System.Collections.Generic;

namespace BirdAtlas.Api.Configuration
{
    /// <summary>
    /// General API information that can be loaded from config or environment variables
    /// </summary>
    public class ApiInformation
    {
        /// <summary>
        /// API id, should be short and will be used in a URI
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// API title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Full API description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// API contacts
        /// </summary>
        public List<ApiInformationContact> Contacts { get; set; }

        /// <summary>
        /// License name
        /// </summary>
        public string LicenseName { get; set; }

        /// <summary>
        /// License URI
        /// </summary>
        public string LicenseUri { get; set; }

        /// <summary>
        /// Terms of Service URI
        /// </summary>
        public string TermsOfServiceUri { get; set; }
    }
}
