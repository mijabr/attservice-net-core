using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using System;
using ViewModel;

namespace AttService
{
    /// <summary>
    /// Class for building the entity data model used for the OData feed.
    /// </summary>
    public class AttEdmModel
    {
        /// <summary>
        /// Creates the entity data model
        /// </summary>
        /// <returns>Entity Data Model</returns>
        public static IEdmModel GetEdmModel(IServiceProvider provider)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder(provider);
            builder.Namespace = "AttService.ViewModel";
            builder.ContainerName = "DefaultContainer";

            builder.EntitySet<ProductCode>("ProductCode");

            return builder.GetEdmModel();
        }
    }
}
