namespace DecoupageStore.Clients.Console
{
    using System;
    using Data.Models;
    using Data.Repositories;
    using System.Linq;
    using System.IO;

    class Startup
    {
        static void Main(string[] args)
        {
            IRepository<Product> products = new Repository<Product>(new Data.DecoupageStoreDbContext());
            IRepository<User> users = new Repository<User>(new Data.DecoupageStoreDbContext());

            User user = users
                .All()
                .FirstOrDefault();

            string userId = user.Id;
            Console.WriteLine(userId);

            Product product = new Product
            {
                Name = "Product1",
                Category = "Bottle",
                Material = "Glass",
                DaysToManufacture = 2,
                FinishedGoodsFlag = false
            };

            products.Add(product);
            products.SaveChanges();

            product.UserId = userId;
            products.SaveChanges();

            Console.WriteLine(product.Id);
        }
    }
}
