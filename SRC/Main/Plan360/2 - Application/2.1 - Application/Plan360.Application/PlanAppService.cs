
using System.Collections.Generic;
using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{

    public class PlanAppService : AppServiceBase<Plan>, IPlanAppService
    {
        private readonly IPlanService _svcPlan;

        public PlanAppService(IPlanService svcPlan)
            : base(svcPlan)
        {
            _svcPlan = svcPlan;
        }

        public IEnumerable<Plan> GetByName(int idCalendar, string strName)
        {
            return _svcPlan.GetByName(idCalendar, strName);
        }

        public IEnumerable<Plan> DoSearch(string strSearch, int? idEnterprise, int? idCalendar)
        {
            return _svcPlan.DoSearch(strSearch, idEnterprise, idCalendar);

        }



        public PlanParameter GetPlanParameter(int idPlanParameter)
        {
            return _svcPlan.GetPlanParameter(idPlanParameter);
        }

        public void UpdateParameters(Plan plan)
        {
            _svcPlan.UpdateParameters(plan);

        }
    }

}
