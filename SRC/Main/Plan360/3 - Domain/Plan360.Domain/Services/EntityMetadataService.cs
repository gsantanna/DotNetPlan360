
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class EntityMetadataService : ServiceBase<EntityMetadata>, IEntityMetadataService
    {
        
        //declare the Repository
         private readonly IEntityMetadataRepository _Repo;

        public EntityMetadataService(IEntityMetadataRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }


   
    }

}
