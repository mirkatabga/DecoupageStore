namespace DecoupageStore.Services.Data
{
    using System.Linq;
    using System.Collections;

    using Contracts;
    using Common.Constants;
    using Common.Extensions;
    using DecoupageStore.Data.Models;
    using DecoupageStore.Data.Repositories;
    using DecoupageStore.Data;
    using Models;
    using System;
    using System.Collections.Generic;
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> usersRepository;

        public UsersService(IRepository<User> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IQueryable<UserNameRoleModel> GetUserNameRolesForPage(int page = GlobalConstants.defaultPageNumber,
            int usersPerPage = GlobalConstants.defaultItemsPerPage)
        {
            DecoupageStoreDbContext dbContext = new DecoupageStoreDbContext();

            return dbContext.Users
                     .Select(usr => new UserNameRoleModel
                     {
                         UserName = usr.UserName,
                         Roles = usr.Roles
                         .Join(dbContext.Roles,
                             ur => ur.RoleId,
                             r => r.Id,
                             (ur, r) => r.Name)
                          .ToList()
                     })
                     .OrderBy(usr => usr.UserName)
                     .Skip(page * usersPerPage)
                     .Take(usersPerPage);
        }

        public int GetPagesCount(int usersPerPage = GlobalConstants.defaultItemsPerPage)
        {
            if (!usersPerPage.IsPositiveOrZero())
            {
                usersPerPage = GlobalConstants.defaultPageNumber;
            }

            int usersCount = usersRepository
                .All()
                .Count();

            int remainder = usersCount % usersPerPage;
            int pagesCount = usersCount / usersPerPage;

            if (remainder > 0)
            {
                pagesCount += 1;
            }

            return pagesCount;
        }

        public List<string> SearchUser(string query)
        {
            return usersRepository
                .All()
                .Select(usr => usr.UserName)
                .Where(name => name.StartsWith(query))
                .Take(5)
                .ToList();
        }
    }
}
