namespace DecoupageStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;

    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Filters;
    using Services.Data.Contracts;
    using ViewModels.Create;
    using ViewModels.View;

    [Authorize(Roles = "Admin,Supplier")]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly IMaterialsService materialsService;

        public ProductsController(IRepository<Product> productRepository, IProductsService productsService, ICategoriesService categoriesService, IMaterialsService materialsService)
        {
            this.productRepository = productRepository;
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.materialsService = materialsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateModelState]
        public ActionResult Create(CreateProductModel model)
        {
            string userId = User.Identity.GetUserId();
            bool isFirstIteration = true;

            Product product = new Product
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                MaterialId = model.MaterialId,
                DaysToManufacture = model.DaysToManufacture,
                UserId = userId,
                DateAdded = DateTime.Now
            };

            this.productRepository.Add(product);
            this.productRepository.SaveChanges();

            string relativePath = String.Format(@"~/Images/{0}/Products/{1}/", userId, product.Id);
            string directory = Server.MapPath(relativePath);

            Directory.CreateDirectory(directory);

            foreach (HttpPostedFileBase image in model.Images)
            {
                if (image == null)
                {
                    continue;
                }

                string formatExtension = Path.GetExtension(image.FileName);
                string imageNewName = Guid.NewGuid().ToString() + formatExtension;
                string fullpath = Path.Combine(directory, imageNewName);
                string fullRelativePath = relativePath + imageNewName;

                image.SaveAs(fullpath);

                product.Images.Add(new ProductImage
                {
                    Path = fullRelativePath,
                    ContentType = image.ContentType,
                    Size = image.InputStream.Length,
                    IsMain = isFirstIteration ? true : false
                });

                isFirstIteration = false;
            }

            this.productRepository.SaveChanges();
            this.productRepository.Dispose();

            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public ActionResult Categories()
        {
            if (!this.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<CategoryViewModel> categories = this.categoriesService
                .All()
                .ProjectTo<CategoryViewModel>()
                .ToList();

            return PartialView("_CategoriesPartial", categories);
        }

        [HttpGet]
        public ActionResult Materials()
        {
            if (!this.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<MaterialViewModel> materials = this.materialsService
                .All()
                .ProjectTo<MaterialViewModel>()
                .ToList();

            return PartialView("_MaterialsPartial", materials);
        }

        [AllowAnonymous]
        public ActionResult Search(string query, string category)
        {
            return null;
        }
    }
}