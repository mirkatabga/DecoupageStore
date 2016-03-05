namespace DecoupageStore.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Services.Data.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.View;
    public class CartController : Controller
    {
        private readonly IProductsService productsService;

        public CartController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public ActionResult Index()
        {
            List<ListProductViewModel> products = (List<ListProductViewModel>)this.Session["cart"];

            return View(products);
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = this.productsService.GetById(id);
            ListProductViewModel producViewModel = Mapper.Map<ListProductViewModel>(product);

            List<ListProductViewModel> products = (List<ListProductViewModel>)this.Session["cart"];

            if (products == null)
            {
                products = new List<ListProductViewModel>();
            }

            products.Add(producViewModel);

            this.Session["cart"] = products;

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}