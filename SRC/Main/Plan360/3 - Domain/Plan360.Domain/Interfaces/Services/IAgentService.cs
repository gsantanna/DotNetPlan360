using System.Collections.Generic;
using Plan360.Domain.Entities;

namespace Plan360.Domain.Interfaces.Services
{
    public interface IAgentService : IServiceBase<Agent>
    {
        IEnumerable<Agent> DoSearch(int? idSalesForce, int? idAgentRole, int idEnterprise, string strSearch);
    }
}
