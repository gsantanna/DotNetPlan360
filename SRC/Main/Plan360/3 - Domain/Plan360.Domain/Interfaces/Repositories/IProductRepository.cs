using System.Collections.Generic;
using Plan360.Domain.Entities;

namespace Plan360.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> DoSearch(int? idBrand, int? idCategory, string strSearch);

    }
}
