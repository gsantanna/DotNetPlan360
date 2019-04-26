using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class EntityRecordRepository : RepositoryBase<EntityRecord>, IEntityRecordRepository
    {
        
 
        public new IEnumerable<EntityRecord>  DoSearch(string strSearch)
        {
            return Db.EntityRecords.Where(f => f.BusinessKey.Contains(strSearch));

        }
    }

}
