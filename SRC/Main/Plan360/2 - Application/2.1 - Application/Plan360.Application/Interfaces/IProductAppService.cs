using System.Collections.Generic;
using Plan360.Domain.Entities;

namespace Plan360.Application.Interfaces
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        IEnumerable<Product> DoSearch(int? idBrand, int? idCategory, string strSearch);

    }
}
