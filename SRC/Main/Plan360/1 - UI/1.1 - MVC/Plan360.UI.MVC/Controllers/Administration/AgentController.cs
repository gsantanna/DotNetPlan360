using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.UI.ViewModels.Agent;

namespace Plan360.UI.MVC.Controllers.Administration
{
    public class AgentController : Controller
    {

        #region constructor

        public IAgentAppService _AppService;

        public AgentController(IAgentAppService appSvc)
        {
            _AppService = appSvc;
        }

        #endregion


        #region JSON

        public JsonResult J_GetAll()
        {
            var ret = Mapper.Map<IEnumerable<Agent>, IEnumerable<AgentViewModel>>(_AppService.GetAll());
            return Json(ret, JsonRequestBehavior.AllowGet);


        }

        public JsonResult J_Find(int id)
        {
            var ret = Mapper.Map<Agent, AgentViewModel>(_AppService.GetById(id));
            return Json(ret, JsonRequestBehavior.AllowGet);

        }

        public JsonResult J_GetByEnterprise(int id)
        {
            var agents =
                _AppService.GetAll()
                    .Where(
                        agent => agent.SalesForce.IdEnterprise == id);


            var ret = Mapper.Map<IEnumerable<Agent>, IEnumerable<AgentViewModel>>(agents);

            return Json(ret, JsonRequestBehavior.AllowGet);

        }

        public JsonResult J_SearchBySalesForce(int? idSalesForce, int? idAgentRole, int idEnterprise, string strSearch)
        {
            var ret = Mapper.Map<IEnumerable<Agent>, IEnumerable<AgentViewModel>>(_AppService.DoSearch( idSalesForce, idAgentRole, idEnterprise, strSearch));
            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // GET: Agent
        public ActionResult Index()
        {
            return View();
        }
    }
}