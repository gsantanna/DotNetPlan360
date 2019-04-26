using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace Plan360.Infra.Data.Repositories
{
    public class EntityMetadataRepository : RepositoryBase<EntityMetadata>, IEntityMetadataRepository
    {
        
 
        public new IEnumerable<EntityMetadata>  DoSearch(string strSearch)
        {
            return Db.EntityMetadatas.Where(f => f.Name.Contains(strSearch));

        }

        
    }

}
