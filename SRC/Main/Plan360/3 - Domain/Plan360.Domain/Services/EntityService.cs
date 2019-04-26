
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class EntityService : ServiceBase<Entity>, IEntityService
    {
        
        //declare the Repository
         private readonly IEntityRepository _Repo;

        public EntityService(IEntityRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

    }

}
