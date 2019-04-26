using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using Plan360.Application.Interfaces;
using Plan360.UI.JsModels;
using Plan360.UI.Resources;

using Plan360.UI.ViewModels.Plan;

using Plan360.Domain.Entities;


namespace Plan360.UI.MVC.Controllers.Plans
{

    public class PlanController : Controller
    {

        #region Constructor

        private readonly IEnterpriseAppService _enterpriseAppService;
        private readonly IPlanAppService _planAppService;
        public PlanController(IEnterpriseAppService enterpriseSvc, IPlanAppService planSvc)
        {
            _enterpriseAppService = enterpriseSvc;
            _planAppService = planSvc;

        }

        #endregion


        #region List

        // GET: Enterprise
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page, int? pageSize, int? idEnterprise, int? idCalendar)
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

            #region Search

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

            //Load all data rows
            var ds = !String.IsNullOrEmpty(searchString) ? _planAppService.DoSearch(searchString, idEnterprise, idCalendar) : _planAppService.GetAll().Where(f => f.IdCalendar == idCalendar && f.IdEnterprise == idEnterprise);

            #endregion

            #region Sort
            //SORT
            ViewBag.CurrentSort = sortOrder;
            //StatusSortParam
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Modified" : "";
            ViewBag.OwnerSortParam = sortOrder == "Owner" ? "Owner_desc" : "Owner";
            ViewBag.AgentsSortParam = sortOrder == "Agents" ? "Agents_desc" : "Agents";
            ViewBag.ProductsSortParam = sortOrder == "Products" ? "Products_desc" : "Products";
            ViewBag.EntitiesSortParam = sortOrder == "Entities" ? "Entities_desc" : "Entities";
            ViewBag.OwnerSortParam = sortOrder == "Created" ? "Created_desc" : "Created";


            switch (sortOrder)
            {
                case "Name":
                    ds = ds.OrderBy(f => f.Name);
                    break;
                case "Name_desc":
                    ds = ds.OrderByDescending(f => f.Name);
                    break;
                case "Owner":
                    ds = ds.OrderBy(f => f.Owner.Name);
                    break;
                case "Owner_desc":
                    ds = ds.OrderByDescending(f => f.Owner.Name);
                    break;
                case "Products":
                    ds = ds.OrderBy(f => f.PlanProducts.Count);
                    break;
                case "Products_desc":
                    ds = ds.OrderByDescending(f => f.PlanProducts.Count);
                    break;
                case "Created":
                    ds = ds.OrderBy(f => f.Created);
                    break;
                case "Created_desc":
                    ds = ds.OrderByDescending(f => f.Created);
                    break;
                case "Modified":
                    ds = ds.OrderBy(f => f.Modified);
                    break;
                case "Modified_desc":
                    ds = ds.OrderByDescending(f => f.Modified);
                    break;
                default:
                    ds = ds.OrderByDescending(f => f.Modified);
                    break;
            }

            #endregion

            #region Pagination

            //if no pagesize is configured,  use 10 as default.
            if (!pageSize.HasValue) pageSize = 10; //TODO Pass it to web.config or other configuration tool like menu item.
                                                   //send pagesize to pager prtial view
            ViewBag.pageSize = pageSize.Value;
            //if no page is selected go to first page
            var pageNumber = (page ?? 1);


            #endregion

            #region Draw

            //Generate the ViewModel and display it
            var vm = Mapper.Map<IEnumerable<Plan>, IEnumerable<PlanViewModel>>(ds);



            //return View with paged list
            return View(vm.ToPagedList(pageNumber, pageSize.Value));

            #endregion

        }

        #endregion


        #region Create and Update

        [HttpGet]
        public ActionResult Create()
        {
            //Add the domains to ViewBag
            ViewBag.Title = Plan360Strings.PLAN_Create;

            //First page has server side initial load. to Avoid Ajax bootlenecks and slow page loading.
            ViewBag.EnterpriseSelect = new SelectList(
               _enterpriseAppService.GetAll().Select(ent => new SelectListItem
               {
                   Value = ent.IdEnterprise.ToString(),
                   Text = ent.Name
               }), "Value", "Text");

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Add the domains to ViewBag
            ViewBag.Title = Plan360Strings.PLAN_Edit;

            var plan = _planAppService.GetById(id);

            //First page has server side initial load. to Avoid Ajax bootlenecks and slow page loading.
            ViewBag.EnterpriseSelect = new SelectList(
               _enterpriseAppService.GetAll().Select(ent => new SelectListItem
               {
                   Value = ent.IdEnterprise.ToString(),
                   Text = ent.Name
               }), "Value", "Text", plan.IdEnterprise.ToString());

            var planVm = Mapper.Map<Plan, PlanViewModel>(plan);



            ViewBag.Agents = Mapper.Map<IEnumerable<Agent>, IEnumerable<JsAgent>>(plan.Agents);
            ViewBag.Products = Mapper.Map<IEnumerable<PlanProduct>, IEnumerable<JsProduct>>(plan.PlanProducts);
            ViewBag.Entities = Mapper.Map<IEnumerable<PlanEntity>, IEnumerable<JsEntity>>(plan.PlanEntities);



            return View("Create", planVm);


        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            Plan plan =
            _planAppService.GetById(id);
            if (plan == null) return new HttpNotFoundResult();


            var objMdl = Mapper.Map<Plan, PlanViewModel>(plan);
            return View(objMdl);
        }


        [HttpPost, ActionName("Remove")]
        public ActionResult RemoveConfirmed(int id)
        {
            Plan plan =
            _planAppService.GetById(id);
            if (plan == null)
            {
                TempData["ErrorMessage"] = Plan360Strings.ERROR_GenericUpdate;
                return RedirectToAction("Remove", new { ID = id });
            };





            // TempData["ErrorMessage"] = Plan360Strings.ERROR_GenericUpdate;
            _planAppService.Remove(plan);


            TempData["SuccessMessage"] = Plan360Strings.Success;
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult Save(int idEnterprise, int idCalendar, int idOwner, string name, JsAgent[] agents, JsProduct[] products, JsEntity[] entities, int idPlan = 0, int idTemplate = 0)
        {
            var objResult = new PlanSaveResult();

            // try
            // {
            Plan objPlan = new Plan
            {
                //TODO: Get this from Authenticated user
                IdCreated = 1,
                IdPlan = idPlan,
                IdEnterprise = idEnterprise,
                IdCalendar = idCalendar,
                IdOwner = idOwner,
                Name = name,
                Agents = Mapper.Map<IEnumerable<JsAgent>, IEnumerable<Agent>>(agents).ToArray(),
                PlanProducts = Mapper.Map<IEnumerable<JsProduct>, IEnumerable<PlanProduct>>(products).ToArray(),
                PlanEntities = Mapper.Map<IEnumerable<JsEntity>, IEnumerable<PlanEntity>>(entities).ToArray()

            };


            if (objPlan.IdPlan == 0) //Insert 
            {
                _planAppService.Add(objPlan);
                objPlan.IdPlan = _planAppService.GetAll().Max(f => f.IdPlan);
            }
            else //Update
            {
                objPlan.Modified = DateTime.Now;
                objPlan.IdModified = 1; //TODO: Get this from the authenticated user.
                _planAppService.Update(objPlan);
            }

            objResult.IdPlan = objPlan.IdPlan;
            objResult.Result = "success";
            objResult.SuccessMessage = Plan360Strings.PLAN_SaveRedirect;
            return Json(objResult);

            /*   }
               catch (Exception ex)
               {
                   objResult.Result = "error";
                   objResult.ErrorCode = "PLAN_CONTROLLER_SAVE";
                   objResult.ErrorMessage = ex.Message;
                   objResult.ErrorDescription = ex.ToString();
                   return Json(objResult);

               }*/


        }

        #endregion


        #region Parametrize


        [HttpGet]
        public ActionResult Parametrize(int id)
        {
            //Load the plan
            var objMdl = Mapper.Map<Plan, PlanViewModel>(_planAppService.GetById(id));

            if (objMdl == null) return new HttpNotFoundResult();




            //Build PackSizes
            ViewBag.ProductInfo = from p in objMdl.PlanProducts
                                  select new JsProduct
                                  {
                                      IdProduct = p.IdProduct.ToString(),
                                      BrandName = p.Product.BrandName,
                                      Name = p.Product.Name,
                                      Code = p.Product.Code,
                                      PackSize = p.Packsize
                                  };




            //Build the view
            return View(objMdl);
        }


        public JsonResult UpdateParameters(List<jsPlanParameter> parameters)
        {
            if (parameters == null || parameters.Count < 1) throw new Exception(Plan360Strings.ERROR_Required);

            //Load the plan 
            var plan = _planAppService.GetById(parameters[0].IdPlan);

            foreach (var par in parameters)
            {
                var reg = plan.PlanParameters.First(f => f.IdPlanParameter == par.IdPlanParameter);

                reg.Percent = par.Percent;
                reg.Count = par.Count;
                reg.Total = par.Total;
                reg.TotalA = par.TotalA;
            }

            _planAppService.UpdateParameters(plan);

            return Json(parameters, JsonRequestBehavior.AllowGet);

        }


        #region Calculations

        public JsonResult J_GetCalculatedTotals(int idPlanParameter, int count, int percentual)
        {
            //TODO: Move this to APP layer
            var planParameter = _planAppService.GetPlanParameter(idPlanParameter);
            var packSize = planParameter.PlanProduct.Packsize;
            var totals = (from ent in planParameter.PlanEntity.PlanEntityCounts
                          select new
                          {
                              Total = Math.Ceiling(ent.Count * ((percentual / 100.00) * count)),
                          }).Select(f =>
                              new
                              {
                                  f.Total,
                                  AdjTotal = Plan360.Utilities.Calculation.GetAdjTotal(packSize, f.Total)
                              }
                ).ToArray();

            var objret = new

            {
                Total = totals.Sum(f => f.Total),
                TotalA = totals.Sum(f => f.AdjTotal)
            };

            return Json(objret, JsonRequestBehavior.AllowGet);

        }


        private class jsProductUsage
        {
            public int idProduct { get; set; }
            public int idAgent { get; set; }
            public int Total { get; set; }
            public int TotalA { get; set; }
            public int PackSize { get; set; }


        }

        //need the plan to get packsize
        public JsonResult J_GetProductUsageInOtherPlans(int idPlan, int? idProduct)
        {
            List<jsProductUsage> objItems = new List<jsProductUsage>();

            //Product || REP || Total || Adjs Total
            // throw new NotImplementedException();
            // = Math.Ceiling(pec.Count * ((pp.Percent / 100.00) * pp.Count))
            //TODO: Move this to APP layer
            var plan = _planAppService.GetById(idPlan);
            var plans = _planAppService.GetAll().Where(f => f.IdCalendar == plan.IdCalendar && f.IdPlan != plan.IdPlan);


            foreach (var p in plans)
            {
                foreach (var prod in p.PlanProducts.Where(f => f.IdProduct == (idProduct.HasValue ? idProduct : f.IdProduct)))
                {
                    foreach (var param in prod.PlanParameters)
                    {
                        foreach (var age in p.Agents)
                        {
                            var qtdEnt = param.PlanEntity.PlanEntityCounts.Count(f => f.IdAgent == age.IdAgent);
                            objItems.Add(new jsProductUsage
                            {
                                idAgent = age.IdAgent,
                                idProduct = prod.IdProduct,
                                PackSize = prod.Packsize,
                                Total = (int)Math.Ceiling(qtdEnt * ((param.Percent / 100.00) * param.Count))
                            });
                        }
                    }
                }
            }
            


            //do the seccond grouping 
            var objRet = from i in objItems                         
                         group i by new { i.idAgent, i.idProduct, i.PackSize } into g
                         select new jsProductUsage
                         {
                             idProduct = g.Key.idProduct,
                             idAgent = g.Key.idAgent,
                             PackSize = g.Key.PackSize,
                             Total = g.Sum(f => f.Total),
                             TotalA = Plan360.Utilities.Calculation.GetAdjTotal(g.Key.PackSize, g.Sum(f => f.Total))
                         };




            //summary the results 
            var objRet2 = from i in objRet
                     group i by i.idProduct into g
                     select new jsProductUsage
                     {
                         idProduct = g.Key,
                         Total = g.Sum(f => f.Total),
                         TotalA = g.Sum(f => f.TotalA)
                     };

    


            //return Json(  new { Items = objItems , Agrupado = objRet, Ajustado = objRet2   }       , JsonRequestBehavior.AllowGet);
            return Json(new {  Ajustado = objRet2 }, JsonRequestBehavior.AllowGet);









        }




        #endregion






        #endregion



        #region Json



        #endregion


    }

}