using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Extensions;
using ViewModelProvider.Data;

namespace CtreeDataAccess
{
    /// <summary>
    /// Product and Service Data Access Class
    /// </summary>
    public class ProductAndServiceCtreeDataAccess : IProductAndServiceDataAccess
    {
        IDbConnection connection;
        public ProductAndServiceCtreeDataAccess(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<ProductAndService> GetAllProductsAndServicesCode(/*CustomFilters customFilters = null*/)
        {
            string query = GetAllProductsAndServicvesCode(/*customFilters*/);
            //var param = (customFilters != null) ? new { customFilters.QueryParameters } : null;
            List<ProductAndService> productsAndServices = connection.Query<ProductAndService>(query/*, param*/).ToList();
            return productsAndServices.AsEnumerable();
        }

        public static string GetAllProductsAndServicvesCode(/*CustomFilters customFilters = null*/)
        {
            string filter = string.Empty;

            string sql = @"SELECT
                            p.code                AS  Code,
                            p.description         AS  Description     
                         FROM product p
                         " + string.Format(filter, "p", "e", "b") + @"

                         UNION SELECT 
                            s.code                AS  Code,
                            s.description         AS  Description   
                         FROM   service s
                         " + string.Format(filter.Replace("instockunit", "saleunit"), "s", "e", "b");

            return sql.CollapseSpaces();
        }
    }
}
