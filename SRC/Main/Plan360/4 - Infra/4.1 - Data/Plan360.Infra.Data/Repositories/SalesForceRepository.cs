using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class SalesForceRepository : RepositoryBase<SalesForce>, ISalesForceRepository
    {
        
 
        public new IEnumerable<SalesForce> DoSearch(string strSearch)
        {
            return Db.SalesForces.Where(f => f.Name.Contains(strSearch));

        }
    }

}
