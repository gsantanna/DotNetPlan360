using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class EntityMetadataAppService : AppServiceBase<EntityMetadata>, IEntityMetadataAppService
    {
        private readonly IEntityMetadataService _svc;

        public EntityMetadataAppService(IEntityMetadataService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }

        

    }
}
