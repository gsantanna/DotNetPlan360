using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class EntityDataAppService : AppServiceBase<EntityData>, IEntityDataAppService
    {
        private readonly IEntityDataService _svc;

        public EntityDataAppService(IEntityDataService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }

        

    }
}
