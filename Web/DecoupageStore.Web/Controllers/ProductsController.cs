namespace DecoupageStore.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    using Data.Models;
    using Data.Repositories;
    using Infrastructure.Filters;
    using ViewModels.Create;
    using Services.Data.Contracts;

    [Authorize(Roles = "Admin,Supplier")]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IProductsService productsService;

        public ProductsController(IRepository<Product> productRepository, IProductsService productsService)
        {
            this.productRepository = productRepository;
            this.productsService = productsService;
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
                Category = model.Category,
                Material = model.Material,
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

        [AllowAnonymous]
        public ActionResult Search(string query, string category)
        {
            return null;
        }
    }
}