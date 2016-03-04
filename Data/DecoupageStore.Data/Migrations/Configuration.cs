namespace DecoupageStore.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<DecoupageStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(DecoupageStoreDbContext context)
        {
            Category[] categories = 
            {
                new Category { Name = "Bottles" },
                new Category { Name = "Boxes" },
                new Category { Name = "Plates" }
            };

            Material[] materials =
            {
                new Material { Name = "Glass" },
                new Material { Name = "Wood" },
                new Material { Name = "Ceramics" }
            };

            context.Roles.AddOrUpdate(
                    r => r.Name,
                    new IdentityRole { Name = "Admin" }
                );

            context.Categories.AddOrUpdate(
                    ctg => ctg.Name,
                    categories
                );

            context.Materials.AddOrUpdate(
                    mtr => mtr.Name,
                    materials
                );

            context.SaveChanges();

            UserStore<User> store = new UserStore<User>(context);
            UserManager<User> manager = new UserManager<User>(store);

            string adminRoleId = context.Roles.FirstOrDefault(r => r.Name == "Admin").Id;

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                User admin = new User { UserName = "Admin", Email = "mirkatabga@gmail.com" };
                admin.Roles.Add(new IdentityUserRole { RoleId = adminRoleId, UserId = admin.Id });

                manager.Create(admin, "xristoW93!ai");
            }

            //string userName = "testuser";
            //List<string> userNames = new List<string>();

            //for (int i = 0; i < 2; i++)
            //{
            //    userNames.Add(userName + i);
            //}

            //foreach (var username in userNames)
            //{
            //    if (!context.Users.Any(usr => usr.UserName == username))
            //    {
            //        User user = new User { UserName = username };

            //        manager.Create(user, username + "1");
            //    }
            //}
        }
    }
}
