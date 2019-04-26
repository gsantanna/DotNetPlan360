using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class AgentRepository : RepositoryBase<Agent>, IAgentRepository
    {



        public new IEnumerable<Agent> DoSearch(string strSearch)
        {

            return Db.Agents.Where(f => f.Name.Contains(strSearch) ||
                                        f.Code.StartsWith(strSearch));
        }

        public  IEnumerable<Agent> DoSearch(int? idSalesForce, int? idAgentRole,  int idEnterprise, string strSearch)
        {

            return Db.Agents.Where(f => f.SalesForce.Enterprise.IdEnterprise == idEnterprise &&
                (f.IdSalesforce == (idSalesForce.HasValue ? idSalesForce : f.IdSalesforce)) &&
                (f.IdAgentrole == (idAgentRole.HasValue ? idAgentRole : f.IdAgentrole)) &&
                (f.Name.Contains(strSearch) ||f.Code.StartsWith(strSearch))
                );

        }




    }

}
