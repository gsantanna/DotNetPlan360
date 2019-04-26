 
using System.Collections.Generic;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class ProductService : ServiceBase<Product>, IProductService
    {
        
        //declare the Repository
         private readonly IProductRepository _Repo;

        public ProductService(IProductRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }


        public IEnumerable<Product> DoSearch(int? idBrand, int? idCategory, string strSearch)
        {
            return _Repo.DoSearch(idBrand, idCategory, strSearch);
        }
    }

}
