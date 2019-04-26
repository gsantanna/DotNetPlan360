using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class AgentRoleService : ServiceBase<AgentRole>, IAgentRoleService
    {
        
        //declare the Repository
         private readonly IAgentRoleRepository _Repo;

        public AgentRoleService(IAgentRoleRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

       


    }

}
