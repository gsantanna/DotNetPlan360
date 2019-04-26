using System.Collections.Generic;
using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class AgentAppService : AppServiceBase<Agent>, IAgentAppService
    {
        private readonly IAgentService _svc;

        public AgentAppService(IAgentService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }


        public IEnumerable<Agent> DoSearch(int? idSalesForce, int? idAgentRole,  int idEnterprise, string strSearch)
        {
            return _svc.DoSearch(idSalesForce, idAgentRole, idEnterprise,  strSearch);
        }
    }
}
