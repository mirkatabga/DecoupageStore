namespace DecoupageStore.Web.Controllers
{
    using Data.Models;
    using Data.Repositories;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    public class TempController : Controller
    {
        private readonly IRepository<ProductImage> productImages;

        public TempController(IRepository<ProductImage> productImages)
        {
            this.productImages = productImages;
        }

        public ActionResult Index()
        {
             return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase photo)
        {
            string directory = @"E:\Temp\";

            //creates directory if it does not exists
            Directory.CreateDirectory(directory);

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(directory, fileName));
            }

            return RedirectToAction("Index");
        }
    }
}