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

            return usersRepository
                .All()
                .Count() / usersPerPage;
        }
    }
}
