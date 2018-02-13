using Extensions;
using System.Collections.Generic;
using System.Linq;
using ViewModel;
using ViewModelProvider.Data;

namespace ViewModelProvider.Builders
{
    public class ProductCodeViewModelBuilder// : IViewModelBuilder, IViewModelCustomFilter
    {
        /// <summary>
        /// The filters
        /// </summary>
        //private CustomFilters filters = null;

        /// <summary>
        /// The products and services data access
        /// </summary>
        private IProductAndServiceDataAccess productAndServiceDA = null;

        /// <summary>
        /// Initialises a new instance of the <see cref="ProductViewModelBuilder"/> class.
        /// </summary>
        /// <param name="productAndServiceDA">The products and services data access.</param>
        public ProductCodeViewModelBuilder(IProductAndServiceDataAccess productAndServiceDA)
        {
            this.productAndServiceDA = productAndServiceDA;
        }

        /// <summary>
        /// Gets or sets the filters.
        /// </summary>
        //CustomFilters IViewModelCustomFilter.Filters
        //{
        //    get { return filters; }
        //    set { filters = value; }
        //}


        public IEnumerable<ProductCode> BuildViewModelEnumeration()
        {
            var data = productAndServiceDA.GetAllProductsAndServicesCode(/*filters*/);
            var view = new List<ProductCode>();

            foreach (var d in data)
            {
                var productCode = new ProductCode() { Code = d.Code.TrimAll(), Description = d.Description.TrimAll() };
                view.Add(productCode);
            }

            return view.OrderBy(x => x.Code).AsEnumerable();
        }
    }
}
