using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class EntityDataService : ServiceBase<EntityData>, IEntityDataService
    {
        
        //declare the Repository
         private readonly IEntityDataRepository _Repo;

        public EntityDataService(IEntityDataRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }


     
    }

}
