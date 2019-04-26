using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Plan360.Application.Interfaces;
using Plan360.UI.ViewModels;
using Plan360.Domain.Entities;

namespace Plan360.UI.MVC.Controllers.Administration
{
    public class UserProfileController : Controller
    {

        #region constructor

        public IUserProfileAppService _AppService;

        public UserProfileController(IUserProfileAppService appSvc)
        {
            _AppService = appSvc;
        }

        #endregion


        #region JSON




        public JsonResult J_GetAll()
        {
            var ret = Mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileViewModel>>(_AppService.GetAll().Where(f=> f.Active ));
            return Json(ret, JsonRequestBehavior.AllowGet);


        }

        public JsonResult J_Find(int id)
        {
            var ret = Mapper.Map<UserProfile, UserProfileViewModel>(_AppService.GetById(id));
            return Json(ret, JsonRequestBehavior.AllowGet);

        }

        public JsonResult J_GetByEnterprise(int id)
        {
            var userProfiles =
                _AppService.GetAll()
                    .Where(
                        profile => profile.UserEnterpriseRoles.Any(f => f.IdEnterprise == id && f.Enterprise.Active)
                    );

            var ret = Mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileViewModel>>(userProfiles);

            return Json(ret, JsonRequestBehavior.AllowGet);

        }

        #endregion


        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProfile/Edit/5
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

        // GET: UserProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProfile/Delete/5
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





    }
}
