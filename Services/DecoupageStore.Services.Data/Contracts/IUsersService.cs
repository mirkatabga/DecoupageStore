namespace DecoupageStore.Services.Data.Contracts
{
    using System.Linq;

    using Models;

    public interface IUsersService
    {
        IQueryable<UserNameRoleModel> GetUserNameRolesForPage(int page = 0, int count = 30);

        int GetPagesCount(int usersPerPage = 30);
    }
}
