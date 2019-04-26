using System.Collections.Generic;
using Plan360.Domain.Entities;

namespace Plan360.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        IEnumerable<Product> DoSearch(int? idBrand, int? idCategory, string strSearch);
    }
}
