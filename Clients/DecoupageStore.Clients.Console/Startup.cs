namespace DecoupageStore.Clients.Console
{
    using System;
    using Data.Models;
    using Data.Repositories;
    using System.Linq;
    using System.IO;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data;

    class Startup
    {
        static void Main(string[] args)
        {
            //    using (DecoupageStoreDbContext dbContext = new DecoupageStoreDbContext())
            //    {
            //        IdentityRole adminRole = dbContext.Roles
            //            .Where(r => r.Name == "Admin")
            //            .FirstOrDefault();

            //        User admin = dbContext.Users
            //            .Where(usr => usr.UserName == "Admin")
            //            .FirstOrDefault();

            //        IdentityUserRole userRole = new IdentityUserRole
            //        {
            //            RoleId = adminRole.Id,
            //            UserId = admin.Id
            //        };

            //        admin.Roles.Add(userRole);

            //        dbContext.SaveChanges();
            //    }
        }
    }
}
