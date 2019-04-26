using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class EntityRecordAppService : AppServiceBase<EntityRecord>, IEntityRecordAppService
    {
        private readonly IEntityRecordService _svc;

        public EntityRecordAppService(IEntityRecordService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }

        

    }
}
