using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.UI.ViewModels.Entity;

namespace Plan360.UI.MVC.Controllers.Entities
{
    public class EntityController : BaseController 
    {

        #region Constructor

        public IEntityAppService _AppService;

        public EntityController(IEntityAppService appSvc)
        {
            _AppService = appSvc;
        }

        #endregion

        #region JSON

        public JsonResult J_GetAll()
        {
            var ret = Mapper.Map<IEnumerable<Entity>, IEnumerable<EntityViewModel>>(_AppService.GetAll().Where(f=>f.Active));
            return Json(ret, JsonRequestBehavior.AllowGet);


        }

        public JsonResult J_GetByEnterprise(int id)
        {
            var ret = Mapper.Map<IEnumerable<Entity>, IEnumerable<EntityViewModel>>(_AppService.GetAll().Where(f => f.IdEnterprise==id && f.Active && f.Enterprise.Active));
            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public JsonResult J_Find(int id)
        {
            var ret = Mapper.Map<Entity, EntityViewModel>(_AppService.GetById(id));
            return Json(ret, JsonRequestBehavior.AllowGet);

        }

       

        #endregion


    }
}