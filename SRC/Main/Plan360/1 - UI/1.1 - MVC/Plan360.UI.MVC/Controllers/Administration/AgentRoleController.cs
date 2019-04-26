using AutoMapper;
using Plan360.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using Plan360.Application.Interfaces;
using Plan360.UI.ViewModels.Agent;

namespace Plan360.UI.MVC.Controllers.Administration
{
    public class AgentRoleController : Controller
    {

        #region Constructor

        public IAgentRoleAppService _AppService;

        public AgentRoleController(IAgentRoleAppService appSvc)
        {
            _AppService = appSvc;
        }

        #endregion

        #region JSON

        public JsonResult J_GetAll()
        {
            var ret = Mapper.Map<IEnumerable<AgentRole>, IEnumerable<AgentRoleViewModel>>(_AppService.GetAll());
            return Json(ret, JsonRequestBehavior.AllowGet);


        }

        public JsonResult J_Find(int id)
        {
            var ret = Mapper.Map<AgentRole, AgentRoleViewModel>(_AppService.GetById(id));
            return Json(ret, JsonRequestBehavior.AllowGet);

        }

       

        #endregion


    }
}