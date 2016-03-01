namespace DecoupageStore.Services.Data.Contracts
{
    using System.Linq;
    using System.Collections.Generic;

    using Models;

    public interface IUsersService
    {
        IQueryable<UserNameRoleModel> GetUserNameRolesForPage(int page = 0, int count = 30);

        IQueryable<UserNameRoleModel> GetUserNameRolesForPage(string query, int page = 0,
            int usersPerPage = 30);

        int GetPagesCount(int usersPerPage = 30);

        int GetPagesCount(string query, int usersPerPage = 30);

        List<string> SearchUser(string query);
        List<string> GetSuggestions(string query);
    }
}
