
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class EntityRecordService : ServiceBase<EntityRecord>, IEntityRecordService
    {

        //declare the Repository
        private readonly IEntityRecordRepository _Repo;

        public EntityRecordService(IEntityRecordRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }


    }

}
