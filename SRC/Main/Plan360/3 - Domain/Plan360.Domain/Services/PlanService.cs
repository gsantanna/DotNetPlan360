using System;
using System.Collections.Generic;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class PlanService : ServiceBase<Plan>, IPlanService
    {

        //declare the Repository
        private readonly IPlanRepository _Repo;

        public PlanService(IPlanRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }


        public IEnumerable<Plan> GetByName(int idCalendar, string strName)
        {
            return _Repo.GetByName(idCalendar, strName);
        }

        public IEnumerable<Plan> DoSearch(string strSearch, int? idEnterprise, int? idCalendar)
        {
            return _Repo.DoSearch(strSearch, idEnterprise, idCalendar);
        }

        public PlanParameter GetPlanParameter(int idPlanParameter)
        {
            return _Repo.GetPlanParameter(idPlanParameter);

        }

        public void UpdateParameters(Plan plan)
        {
            _Repo.UpdateParameters(plan);

        }
    }

}
