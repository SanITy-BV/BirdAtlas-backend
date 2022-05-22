/*
* More info: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#use-application-model-to-customize-attribute-routes
*/

using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BirdAtlas.Api.Configuration
{
    /// <summary>
    /// Implementation of <see cref="IApplicationModelConvention"/> that prefixes all routes with a global route prefix.
    /// Can be used to apply a 'domain' to the API route, also simplifies API versioning.
    /// </summary>
    internal class GlobalRouteConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _globalPrefix;

        /// <summary>
        /// Creates  new <see cref="GlobalRouteConvention"/>.
        /// </summary>
        /// <param name="routeTemplateProvider">Prefix route</param>
        public GlobalRouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            _globalPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        /// <inheritdoc />
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                // self-defined routes (by attribute)
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_globalPrefix,
                            selectorModel.AttributeRouteModel);
                    }
                }

                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = _globalPrefix;
                    }
                }
            }
        }
    }
}
