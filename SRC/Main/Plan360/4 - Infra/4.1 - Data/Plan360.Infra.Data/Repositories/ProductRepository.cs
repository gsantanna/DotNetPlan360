using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        
 
        public new IEnumerable<Product> DoSearch(string strSearch)
        {
            return Db.Products.Where(f => f.Name.Contains(strSearch)         );

        }

        public IEnumerable<Product> DoSearch(int? idBrand, int? idCategory, string strSearch)
        {

            return Db.Products.Where(f =>
                (f.IdBrand == (idBrand.HasValue ? idBrand : f.IdBrand)) &&
                (f.IdCategory == (idCategory.HasValue ? idCategory : f.IdCategory)) &&
                (f.Name.Contains(strSearch) || f.Code.StartsWith(strSearch) || f.Description.Contains(strSearch) || f.Ean.Contains(strSearch) )
                );

        }






    }

}
