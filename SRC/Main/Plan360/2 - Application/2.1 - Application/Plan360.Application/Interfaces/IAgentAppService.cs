using System.Collections.Generic;
using Plan360.Domain.Entities;

namespace Plan360.Application.Interfaces
{
    public interface IAgentAppService : IAppServiceBase<Agent>
    {
        IEnumerable<Agent> DoSearch(int? idSalesForce, int? idAgentRole, int idEnterprise, string strSearch);
    }
}
