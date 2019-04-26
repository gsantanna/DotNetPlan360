using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.UI.Resources;
using Plan360.UI.ViewModels;


namespace Plan360.UI.MVC.Controllers.Administration
{
    public class EnterpriseController : Controller
    {

        #region constructor
        //Create the Application access object
        private readonly IEnterpriseAppService _appService;

        //Constructor using Interface created by Ninject
        public EnterpriseController(IEnterpriseAppService appSvc)
        {
            _appService = appSvc;
        }

        #endregion


        #region JSON

        public JsonResult J_GetAll()
        {
            var ret = Mapper.Map<IEnumerable<Enterprise>, IEnumerable<EnterpriseViewModel>>(_appService.GetAll().Where(f=>f.Active ));
            return Json(ret, JsonRequestBehavior.AllowGet);


        }

        #endregion

        // GET: Enterprise
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page, int? pageSize)
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
            var ds = !String.IsNullOrEmpty(searchString) ? _appService.DoSearch(searchString) : _appService.GetAll();

            #endregion

            #region Sort
            //SORT
            ViewBag.CurrentSort = sortOrder;
            //StatusSortParam
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StatusSortParam = sortOrder == "status" ? "status_desc" : "status";
            switch (sortOrder)
            {
                case "name":
                    ds = ds.OrderBy(f => f.Name);
                    break;
                case "name_desc":
                    ds = ds.OrderByDescending(f => f.Name);
                    break;
                case "id":
                    ds = ds.OrderBy(f => f.IdEnterprise);
                    break;
                case "id_desc":
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
            var vm = Mapper.Map<IEnumerable<Enterprise>, IEnumerable<EnterpriseViewModel>>(ds);

            //return View with paged list
            return View(vm.ToPagedList(pageNumber, pageSize.Value));

            #endregion

        }

        // GET: Enterprise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enterprise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnterpriseViewModel mdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Generate the Model from viewmodel 
                    var _mdl = Mapper.Map<EnterpriseViewModel, Enterprise>(mdl);

                    //add the item in database
                    _appService.Add(_mdl);


                    //Redirect to index view.
                    TempData["SuccessMessage"] = Plan360Strings.Success;
                    return RedirectToAction("Index");
                }
                else
                {

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

        // GET: Enterprise/Edit/5
        public ActionResult Edit(int id)
        {
            var _mdl = Mapper.Map<Enterprise, EnterpriseViewModel>(_appService.GetById(id));
            return View(_mdl);
        }

        // POST: Enterprise/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EnterpriseViewModel mdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _mdl = Mapper.Map<EnterpriseViewModel, Enterprise>(mdl);
                    _appService.Update(_mdl);
                    TempData["SuccessMessage"] = Plan360Strings.Success;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = Plan360Strings.ERROR_GenericUpdate;
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }


    }
}
