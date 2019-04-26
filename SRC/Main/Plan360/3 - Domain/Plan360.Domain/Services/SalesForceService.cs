
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class SalesForceService : ServiceBase<SalesForce>, ISalesForceService
    {
        
        //declare the Repository
         private readonly ISalesForceRepository _Repo;

        public SalesForceService(ISalesForceRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

       


    }

}
