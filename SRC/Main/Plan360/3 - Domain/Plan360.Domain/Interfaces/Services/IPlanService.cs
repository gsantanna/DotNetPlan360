using System.Collections.Generic;
using Plan360.Domain.Entities;

namespace Plan360.Domain.Interfaces.Services
{
    public interface IPlanService : IServiceBase<Plan>
    {
        IEnumerable<Plan> GetByName(int idCalendar, string strName);

        IEnumerable<Plan> DoSearch(string strSearch, int? idEnterprise, int? idCalendar);

        void UpdateParameters(Plan plan);

        PlanParameter GetPlanParameter(int idPlanParameter);

    }
}
