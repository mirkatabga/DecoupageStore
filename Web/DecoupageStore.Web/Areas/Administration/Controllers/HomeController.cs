using System.Web.Mvc;

namespace DecoupageStore.Web.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administration/Home
        public ActionResult Navigation()
        {
            return View();
        }
    }
}