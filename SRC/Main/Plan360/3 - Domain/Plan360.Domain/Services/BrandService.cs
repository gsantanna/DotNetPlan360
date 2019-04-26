using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class BrandService : ServiceBase<Brand>, IBrandService
    {
        
        //declare the Repository
         private readonly IBrandRepository _Repo;

        public BrandService(IBrandRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

       


    }

}
