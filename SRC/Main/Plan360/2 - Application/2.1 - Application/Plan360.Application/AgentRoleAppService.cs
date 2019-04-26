using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class AgentRoleAppService : AppServiceBase<AgentRole>, IAgentRoleAppService
    {
        private readonly IAgentRoleService _svc;

        public AgentRoleAppService(IAgentRoleService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }

        

    }
}
