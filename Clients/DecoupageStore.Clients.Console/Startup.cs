namespace DecoupageStore.Clients.Console
{
    using System;
    using Data.Models;
    using Data.Repositories;
    using System.Linq;
    using System.IO;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Data;
    using System.Collections.Generic;
    using System.Data.Entity;
    class Startup
    {
        static void Main(string[] args)
        {
            DecoupageStoreDbContext db = new DecoupageStoreDbContext();

            var l = db.Users
                 .Select(u => new
                 {
                     Roles = u.Roles.Join(db.Roles,
                         ur => ur.RoleId,
                         r => r.Id,
                         (ur, r) => new
                         {
                             Role = r.Name
                         })
                         .ToList(),
                     UserName = u.UserName
                 })
                 .ToList();

            foreach (var x in l)
            {
                Console.WriteLine();
                Console.Write(x.UserName + " Roles: ");

                foreach (var role in x.Roles)
                {
                    Console.Write(role.Role +  " ");
                }
            }
        }
    }
}
