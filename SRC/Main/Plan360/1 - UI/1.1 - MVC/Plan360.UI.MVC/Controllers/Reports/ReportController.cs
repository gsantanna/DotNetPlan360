using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using Plan360.Application.Interfaces;
using Plan360.UI.JsModels;
using Plan360.UI.Resources;

using Plan360.Domain.Entities;


namespace Plan360.UI.MVC.Controllers.Plans
{

    public class ReportController : Controller
    {

        #region Constructor

        private readonly IEnterpriseAppService _enterpriseAppService;
        private readonly IPlanAppService _planAppService;
        public ReportController(IEnterpriseAppService enterpriseSvc, IPlanAppService planSvc)
        {
            _enterpriseAppService = enterpriseSvc;
            _planAppService = planSvc;

        }

        #endregion


        #region List

        // GET: Enterprise
        public ActionResult Summary(string sortOrder, string searchString, string currentFilter, int? page, int? pageSize, int? idEnterprise, int? idCalendar)
        {
            //get the default enterprse and default calendar 
            if (!(idEnterprise.HasValue)) idEnterprise = Plan360.Utilities.Defaults.GetDefaultEnterprise();

            //If no calendar was selected assume the newest one.
            var calendars = _enterpriseAppService.GetById(idEnterprise.Value)
                .Calendars.OrderByDescending(f => f.Sartdate);

            if (!(idCalendar.HasValue)) idCalendar = calendars.First().IdCalendar;

            #region Combos

            ViewBag.EnterpriseSelect = new SelectList(_enterpriseAppService.GetAll().Where(f => f.Active).Select(ent => new SelectListItem
            {
                Value = ent.IdEnterprise.ToString(),
                Text = ent.Name
            }), "Value", "Text", idEnterprise.ToString());

            ViewBag.IdEnterprise = idEnterprise;

            ViewBag.CalendarSelect = new SelectList(calendars.Select(cal => new SelectListItem
            {
                Value = cal.IdCalendar.ToString(),
                Text = cal.Name
            }), "Value", "Text", idCalendar.ToString());

            ViewBag.IdCalendar = idCalendar;

            #endregion


            if (searchString != null)
            {
                page = 1;
                ViewBag.CurrentFilter = searchString;

            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;



            //Product || REP || Total || Adjs Total
            // throw new NotImplementedException();
            // = Math.Ceiling(pec.Count * ((pp.Percent / 100.00) * pp.Count))
            //TODO: Move this to APP layer
            var plans = _planAppService.GetAll().Where(f => f.IdCalendar == idCalendar);

            List<ViewModels.Report.Summary> objItems = new List<ViewModels.Report.Summary>();


            foreach (var p in plans)
            {
                foreach (var prod in p.PlanProducts)
                {
                    foreach (var param in prod.PlanParameters)
                    {
                        foreach (var age in p.Agents)
                        {
                            var qtdEnt = param.PlanEntity.PlanEntityCounts.Count(f => f.IdAgent == age.IdAgent);
                            objItems.Add(new ViewModels.Report.Summary
                            {
                                AgentCode = age.Code , 
                                AgentErpCode = age.IdErp ,
                                AgentName= age.Name , 
                                ProductCode = prod.Product.Code, 
                                ProductName = prod.Product.Name, 
                                ProductType = prod.Product.ProductCategory.Name,
                                CalendarName = param.Plan.Calendar.Name,
                                PackSize = prod.Product.Packsize,
                                Total  = (int)Math.Ceiling(qtdEnt * ((param.Percent / 100.00) * param.Count))
                                
                            });
                        }
                    }
                }
            }


            //do the grouping
            var objRet = from i in objItems
                         where i.Total > 0
                         group i by new { i.AgentCode, i.AgentErpCode, i.AgentName, i.ProductCode, i.ProductName, i.ProductType, i.CalendarName , i.PackSize} into g
                         select new ViewModels.Report.Summary
                         {
                             AgentCode      = g.Key.AgentCode,
                             AgentErpCode   = g.Key.AgentErpCode, 
                             AgentName      = g.Key.AgentName, 
                             ProductCode    = g.Key.ProductCode, 
                             CalendarName   = g.Key.CalendarName, 
                             ProductName    = g.Key.ProductName,
                             ProductType    = g.Key.ProductType,                                                                                    
                             Total          = g.Sum(f => f.Total),
                             TotalA = Plan360.Utilities.Calculation.GetAdjTotal(g.Key.PackSize, g.Sum(f => f.Total))
                         };





            return View(objRet.Where(f => f.TotalA > 0).OrderBy(f=> f.CalendarName).ThenBy(f=> f.AgentCode).ThenBy(f=> f.ProductName)) ;

            


        }

        


        #endregion




    }

}