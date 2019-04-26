
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.UI.ViewModels.Entity;

namespace Plan360.UI.MVC.Controllers.Entities
{
    public class EntityMetadataController : Controller
    {

        private IEntityMetadataAppService _AppService;

            public EntityMetadataController(IEntityMetadataAppService appSvc)
        {
            _AppService = appSvc;
        }


            #region JSON

            public JsonResult J_GetAll()
            {
                var ret = Mapper.Map<IEnumerable<EntityMetadata>, IEnumerable<EntityMetadataViewModel>>(_AppService.GetAll().Where(f => f.Active));
                return Json(ret, JsonRequestBehavior.AllowGet);


            }

            public JsonResult J_GetByEntity(int id)
            {
                var ret = Mapper.Map<IEnumerable<EntityMetadata>, IEnumerable<EntityMetadataViewModel>>(_AppService.GetAll().Where(f=> f.Active && f.IdEntity== id));
                return Json(ret, JsonRequestBehavior.AllowGet);
            }

       



            #endregion














    }
}