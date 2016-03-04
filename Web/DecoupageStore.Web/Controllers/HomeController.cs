

namespace DecoupageStore.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using DecoupageStore.Data.Models;
    using DecoupageStore.Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ViewModels.View;

    public class HomeController : Controller
    {
        private ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public ActionResult Index()
        {
            List<CategoryViewModel> categories = this.categoriesService
                .All()
                .ProjectTo<CategoryViewModel>()
                .ToList();

            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}