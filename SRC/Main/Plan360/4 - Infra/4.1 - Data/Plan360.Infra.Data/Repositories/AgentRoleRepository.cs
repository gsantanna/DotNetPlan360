using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class AgentRoleRepository : RepositoryBase<AgentRole>, IAgentRoleRepository
    {


        public new IEnumerable<AgentRole> DoSearch(string strSearch)
        {
            return Db.AgentRoles.Where(f => f.Name.Contains(strSearch));                                     

        }


    }

}
