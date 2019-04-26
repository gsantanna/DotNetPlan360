using System.Web.Mvc;
using Plan360.Application.Interfaces;

namespace Plan360.UI.MVC.Controllers.Utilities
{
    public class PhotoController : Controller
    {
        private readonly IBrandAppService _brandAppSvc;
        private readonly IProductAppService _productAppSvc;

        public PhotoController(IBrandAppService brandAppSvc, IProductAppService productAppSvc)
        {
            _brandAppSvc = brandAppSvc;
            _productAppSvc = productAppSvc;

        }

        [HttpGet]
        public FileContentResult Brand(int id)
        {
            var item = _brandAppSvc.GetById(id);

            if (item == null || item.Photo == null)
            {
                //Load the no picture image 
                return null;
            }
            
                
            return File(item.Photo, "image/jpg");
            
        }

        [HttpGet]
        public FileContentResult Product(int id)
        {
            var item = _productAppSvc.GetById(id);

            if (item == null || item.Photo == null)
            {
                //Load the no picture image 
                return null;
            }
            
            return File(item.Photo, "image/jpg");
            
        }


    }
}