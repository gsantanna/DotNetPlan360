using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class EntityAppService : AppServiceBase<Entity>, IEntityAppService
    {
        private readonly IEntityService _svc;

        public EntityAppService(IEntityService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }

        

    }
}
