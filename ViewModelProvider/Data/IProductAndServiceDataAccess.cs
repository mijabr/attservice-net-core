using System.Collections.Generic;

namespace ViewModelProvider.Data
{
    public interface IProductAndServiceDataAccess
    {
        IEnumerable<ProductAndService> GetAllProductsAndServicesCode(/*CustomFilters filters = null*/);
    }
}
