using System.Web.Mvc;

namespace DecoupageStore.Web.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult Navigation()
        {
            return View();
        }
    }
}