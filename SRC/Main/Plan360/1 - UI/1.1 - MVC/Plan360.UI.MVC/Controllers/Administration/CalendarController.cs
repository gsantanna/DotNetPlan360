using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using Plan360.Application.Interfaces;
using Plan360.UI.ViewModels;
using Plan360.Domain.Entities;
using Plan360.UI.Resources;

namespace Plan360.UI.MVC.Controllers.Administration
{
    public class CalendarController : Controller
    {

        #region constructor

        public ICalendarAppService _AppService;
        public IEnterpriseAppService _AppServiceEnterprise;

        public CalendarController(ICalendarAppService appSvc, IEnterpriseAppService appSvcEnt)
        {
            _AppService = appSvc;
            _AppServiceEnterprise = appSvcEnt;
        }

        #endregion

        #region JSON


        public JsonResult J_GetAll()
        {
            var ret = Mapper.Map<IEnumerable<Calendar>, IEnumerable<CalendarViewModel>>(_AppService.GetAll().Where(f=> f.Enterprise.Active &&  f.Active));
            return Json(ret, JsonRequestBehavior.AllowGet);


        }

        public JsonResult J_Find(int id)
        {
            var ret = Mapper.Map<Calendar, CalendarViewModel>(_AppService.GetById(id));
            return Json(ret, JsonRequestBehavior.AllowGet);

        }

        public JsonResult J_GetByEnterprise(int id)
        {
            var ret =
                Mapper.Map<IEnumerable<Calendar>, IEnumerable<CalendarViewModel>>(_AppService.GetAll().Where(f => f.IdEnterprise == id && f.Enterprise.Active && f.Active));

            return Json(ret, JsonRequestBehavior.AllowGet);



        }

        #endregion


        // GET: Calendar
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page, int? pageSize, int? id_enterprise)
        {

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
            var ds = !String.IsNullOrEmpty(searchString) ? _AppService.DoSearch(searchString) : _AppService.GetAll();

            //IF user selected the enterprise value in combobox.
            if(id_enterprise.HasValue && id_enterprise > 0 )
            {
                ds = ds.Where(f => f.IdEnterprise == id_enterprise);
                ViewBag.CurrentEnterprise = id_enterprise;
            }

            #endregion

            #region Sort
            //SORT
            ViewBag.CurrentSort = sortOrder;
            //StatusSortParam
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StatusSortParam = sortOrder == "status" ? "status_desc" : "status";
            ViewBag.EnterpriseSortParam = sortOrder == "enterprise" ? "enterprise_desc" : "enterprise";
            ViewBag.StartDateSortParam = sortOrder == "start_date" ? "start_date_desc" : "start_date";
            ViewBag.EndDateSortParam = sortOrder == "end_date" ? "end_date_desc" : "end_date";


            switch (sortOrder)
            {
                case "name":
                    ds = ds.OrderBy(f => f.Name);
                    break;
                case "name_desc":
                    ds = ds.OrderByDescending(f => f.Name);
                    break;
                case "start_date":
                    ds = ds.OrderBy(f => f.Sartdate);
                    break;
                case "start_date_desc":
                    ds = ds.OrderByDescending(f => f.Sartdate);
                    break;
                case "end_date":
                    ds = ds.OrderBy(f => f.Enddate);
                    break;
                case "end_date_desc":
                    ds = ds.OrderByDescending(f => f.Enddate);
                    break;
                case "enterprise":
                    ds = ds.OrderBy(f => f.IdEnterprise);
                    break;
                case "enterprise_desc":
                    ds = ds.OrderByDescending(f => f.IdEnterprise);
                    break;
                case "status":
                    ds = ds.OrderBy(f => f.Active);
                    break;
                case "status_desc":
                    ds = ds.OrderByDescending(f => f.Active);
                    break;
                default:
                    ds = ds.OrderBy(f => f.Name);
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
            var vm = Mapper.Map<IEnumerable<Calendar>, IEnumerable<CalendarViewModel>>(ds);

            //return View with paged list
            return View(vm.ToPagedList(pageNumber, pageSize.Value));

            #endregion

        }








        // GET: Calendar/Create
        public ActionResult Create()
        {
            ViewBag.EnterpriseSelect = new SelectList(
              _AppServiceEnterprise.GetAll().Where(f => f.Active).Select(ent => new SelectListItem
              {
                  Value = ent.IdEnterprise.ToString(),
                  Text = ent.Name
              }), "Value", "Text");


            return View();
        }

        // POST: Calendar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CalendarViewModel mdl)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //Generate the Model from viewmodel 
                    var _mdl = Mapper.Map<CalendarViewModel, Calendar>(mdl);

                    //Genrete addition mapping atributes
                    _mdl.Created = DateTime.Now;
                    _mdl.Modified = DateTime.Now;




                    //add the item in database
                    _AppService.Add(_mdl);


                    //Redirect to index view.
                    TempData["SuccessMessage"] = Plan360Strings.Success;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.EnterpriseSelect = new SelectList(
                    _AppServiceEnterprise.GetAll().Where(f => f.Active).Select(ent => new SelectListItem
                    {
                        Value = ent.IdEnterprise.ToString(),
                        Text = ent.Name
                    }), "Value", "Text");


                    TempData["ErrorMessage"] = Plan360Strings.ERROR_GenericUpdate;
                    return View(mdl);

                }


            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = String.Format("{0} - {1}", Plan360Strings.ERROR_GenericUpdate, ex.Message);

                return View(mdl);
            }


        }




        #region Pendente

        // GET: Calendar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calendar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calendar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calendar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #endregion






    }
}
