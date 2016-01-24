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

    public class ProductsController : Controller
    {
        private readonly IRepository<Product> productRepository;

        public ProductsController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()

        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [ValidateModelState]
        public ActionResult Create(CreateProductModel model)
        {
            string userId = User.Identity.GetUserId();

            Product product = new Product
            {
                Name = model.Name,
                Category = model.Category,
                Material = model.Material,
                DaysToManufacture = model.DaysToManufacture,
                UserId = userId
            };

            this.productRepository.Add(product);
            this.productRepository.SaveChanges();

            string directory = Server.MapPath(
                String.Format(@"~/Images/{0}/Products/{1}/", userId, product.Id));

            Directory.CreateDirectory(directory);

            foreach (HttpPostedFileBase image in model.Images)
            {
                string formatExtension = Path.GetExtension(image.FileName);
                string imageNewName = Guid.NewGuid().ToString() + formatExtension;
                string fullPath = Path.Combine(directory, imageNewName);

                image.SaveAs(fullPath);

                product.Images.Add(new ProductImage
                {
                    Path = fullPath,
                    ContentType = image.ContentType,
                    Size = image.InputStream.Length
                });              
            }

            this.productRepository.SaveChanges();
            this.productRepository.Dispose();

            return RedirectToAction("Index", "Products");
        }
    }
}