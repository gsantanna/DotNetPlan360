using System.Collections.Generic;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class AgentService : ServiceBase<Agent>, IAgentService
    {
        
        //declare the Repository
         private readonly IAgentRepository _Repo;

        public AgentService(IAgentRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }


        public IEnumerable<Agent> DoSearch(int? idSalesForce, int? idAgentRole, int idEnterprise, string strSearch)
        {
            return _Repo.DoSearch(idSalesForce, idAgentRole, idEnterprise, strSearch);

        }
    }

}
