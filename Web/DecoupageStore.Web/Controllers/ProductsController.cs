namespace DecoupageStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    using Data.Models;
    using Data.Repositories;
    using Filters;
    using ViewModels.Create;

    public class ProductsController : Controller
    {
        private readonly IRepository<User> usersRepository;

        public ProductsController(IRepository<User> userRepository)
        {
            this.usersRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateModelState]
        public ActionResult Create(CreateProductModel model)
        {
            string currUserId = this.User.Identity.GetUserId();

            User currentUser = usersRepository
                .All()
                .FirstOrDefault(usr => usr.Id == currUserId);

            Product product = new Product
            {
                Category = model.Category,
                Material = model.Material,
                Name = model.Name,
                DaysToManufacture = model.DaysToManufacture,
                FinishedGoodsFlag = model.FinishedGoodsFlag
            };

            ProductImage prodImage = new ProductImage
            {
                Path = @"D:\Temp\" + model.File.FileName,
                Format = model.File.FileName.Split(new char[] { '.' })[1],
                Size = model.File.ContentLength
            };

            product.Images.Add(prodImage);
            currentUser.Products.Add(product);

            usersRepository.SaveChanges();
            usersRepository.Dispose();

            return RedirectToAction("Index", "Products");
        }
    }
}