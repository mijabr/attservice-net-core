using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using System.Collections.Generic;
using ViewModel;
using ViewModelProvider.Builders;

namespace AttService.Controllers
{
    public class ProductCodeController : ODataController
    {
        ProductCodeViewModelBuilder builder;
        public ProductCodeController(ProductCodeViewModelBuilder builder)
        {
            this.builder = builder;
        }

        [EnableQuery(MaxNodeCount = int.MaxValue)]
        public IEnumerable<ProductCode> Get(ODataQueryOptions<ProductCode> options)
        {
            //ODataUriParser parser = AggregateServices.GetUriParser(ServiceRoot, options.Request.RequestUri);
            //FilterClause filterClause = parser.ParseFilter();
            //CustomFilters customFilters = new CustomFilters(parser.ParseFilter());
            var view = builder.BuildViewModelEnumeration();
            return view;
        }
    }
}
