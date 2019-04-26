using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        
 
        public new IEnumerable<ProductCategory>  DoSearch(string strSearch)
        {
            return Db.ProductCategories.Where(f => f.Name.Contains(strSearch) || f.InvoiceConfig.Equals(strSearch)   ) ;

        }
    }

}
