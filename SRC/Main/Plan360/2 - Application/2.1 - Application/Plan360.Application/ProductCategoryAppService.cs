using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class ProductCategoryAppService : AppServiceBase<ProductCategory>, IProductCategoryAppService
    {
        private readonly IProductCategoryService _svc;

        public ProductCategoryAppService(IProductCategoryService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }


    }
}
