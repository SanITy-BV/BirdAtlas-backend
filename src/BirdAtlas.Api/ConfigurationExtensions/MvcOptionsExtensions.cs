using BirdAtlas.Api.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BirdAtlas.Api.ConfigurationExtensions
{
    /// <summary>
    /// Extensions class for <see cref="MvcOptions"/>.
    /// </summary>
    public static class MvcOptionsExtensions
    {
        /// <summary>
        /// Extends the MvcOptions with the ability to prefix all routes with the same prefix for all controllers in the assembly.
        /// </summary>
        /// <param name="options">Mvc builder options</param>
        /// <param name="routeAttribute">Route prefix attribute</param>
        public static void UseGlobalRoutePrefix(this MvcOptions options, IRouteTemplateProvider routeAttribute)
        {
            options.Conventions.Insert(0, new GlobalRouteConvention(routeAttribute));
        }
    }
}
