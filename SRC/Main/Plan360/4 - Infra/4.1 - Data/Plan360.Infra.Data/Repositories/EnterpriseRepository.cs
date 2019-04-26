using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class EnterpriseRepository : RepositoryBase<Enterprise>, IEnterpriseRepository
    {
        
 
        public new IEnumerable<Enterprise>  DoSearch(string strSearch)
        {
            return Db.Enterprises.Where(f => f.Name.Contains(strSearch));

        }
    }

}
