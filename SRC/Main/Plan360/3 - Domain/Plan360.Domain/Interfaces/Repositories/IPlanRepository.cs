using System.Collections.Generic;
using Plan360.Domain.Entities;

namespace Plan360.Domain.Interfaces.Repositories
{
    public interface IPlanRepository : IRepositoryBase<Plan>
    {
        IEnumerable<Plan> GetByName(int idCalendar, string strName);

        IEnumerable<Plan> DoSearch(string strSearch, int? idEnterprise, int? idCalendar);

        PlanParameter GetPlanParameter(int idPlanParameter);

        void UpdateParameters(Plan plan);

    }
}
