
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class ProductCategoryService : ServiceBase<ProductCategory>, IProductCategoryService
    {
        
        //declare the Repository
         private readonly IProductCategoryRepository _Repo;

        public ProductCategoryService(IProductCategoryRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

       
    }

}
