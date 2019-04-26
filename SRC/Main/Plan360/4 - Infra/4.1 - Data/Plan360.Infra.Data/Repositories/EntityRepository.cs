using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class EntityRepository : RepositoryBase<Entity>, IEntityRepository
    {
        public new IEnumerable<Entity>  DoSearch(string strSearch)
        {
            return Db.Entities.Where(f => f.Name.Contains(strSearch) || f.Description.Contains(strSearch));

        }
    }

}
