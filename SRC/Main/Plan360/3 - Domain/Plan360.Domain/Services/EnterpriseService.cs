using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class EnterpriseService : ServiceBase<Enterprise>, IEnterpriseService
    {
        
        //declare the Repository
         private readonly IEnterpriseRepository _Repo;

        public EnterpriseService(IEnterpriseRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

       
    }

}
