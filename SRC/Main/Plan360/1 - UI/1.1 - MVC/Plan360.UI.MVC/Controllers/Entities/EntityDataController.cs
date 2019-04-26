using System.Linq;
using System.Web.Mvc;
using Plan360.Application.Interfaces;
using Plan360.UI.JsModels;
using AutoMapper;
using System.Collections.Generic;
using Plan360.Domain.Entities;

namespace Plan360.UI.MVC.Controllers.Entities
{
    public class EntityDataController : Controller
    {

        private readonly IEntityMetadataAppService _entityMetadataApp;
        private readonly IEntityDataAppService _entityDataApp;


        public EntityDataController(IEntityMetadataAppService _entityMetadataApp, IEntityDataAppService _entityDataApp)
        {

            this._entityMetadataApp = _entityMetadataApp;
            this._entityDataApp = _entityDataApp;
        }


        #region JSON


        public JsonResult J_GetDistinctValuesByEntityMetadata(int id, JsAgent[] agents)
        {
            if (agents == null || !(agents.Length > 0)) return null;


            


            var eds = from ems in _entityDataApp.DoSearch(id.ToString())
                      join a in agents on ems.EntityRecord.IdAgent equals a.IdAgent
                      where ems.IdEntitymetadata == id
                      select new { ems.EntityRecord.IdAgent, ems.Value };


            var dval = from d in eds
                           //join a in age on d.EntityRecord.IdAgent equals  a.IdAgent
                       group d.Value by d.Value
                           into dd
                       select new { Value = dd.Key, Count = dd.Count() };


            return Json(dval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult J_GetDistinctValuesByEntityMetadataValue(int id, string value, JsAgent[] agents)
        {
            if (agents == null || !(agents.Length > 0)) return null;

            //Load the values using the Metadata's id.
            



            var dval = from d in _entityDataApp.DoSearch(id.ToString())                               
                       join a in agents on d.EntityRecord.IdAgent equals a.IdAgent
                       where d.Value == value && d.IdEntitymetadata == id
                       group d.Value by d.Value
                           into dd
                       select new { Value = dd.Key, Count = dd.Count() };

            return Json(dval.Sum(f => f.Count), JsonRequestBehavior.AllowGet);
        }


        #endregion














    }
}