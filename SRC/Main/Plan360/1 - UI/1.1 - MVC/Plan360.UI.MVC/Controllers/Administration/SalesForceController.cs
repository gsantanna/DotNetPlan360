using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Plan360.Application.Interfaces;
using Plan360.UI.ViewModels;
using Plan360.Domain.Entities;

namespace Plan360.UI.MVC.Controllers.Administration
{
    public class SalesForceController : Controller
    {

        #region constructor

        public ISalesForceAppService _AppService;

        public SalesForceController(ISalesForceAppService appSvc)
        {
            _AppService = appSvc;
        }

        #endregion

        #region JSON

        public JsonResult J_GetAll()
        {
            var ret = Mapper.Map<IEnumerable<SalesForce>, IEnumerable<SalesForceViewModel>>(_AppService.GetAll().Where(f=> f.Enterprise.Active));
            return Json(ret, JsonRequestBehavior.AllowGet);


        }

        public JsonResult J_Find(int id)
        {
            var ret = Mapper.Map<SalesForce, SalesForceViewModel>(_AppService.GetById(id));
            return Json(ret, JsonRequestBehavior.AllowGet);

        }

        public JsonResult J_GetByEnterprise(int id)
        {
            var ret =
                Mapper.Map<IEnumerable<SalesForce>, IEnumerable<SalesForceViewModel>>(_AppService.GetAll().Where(f => f.IdEnterprise == id && f.Enterprise.Active));

            return Json(ret, JsonRequestBehavior.AllowGet);



        }


        #endregion









    }
}
