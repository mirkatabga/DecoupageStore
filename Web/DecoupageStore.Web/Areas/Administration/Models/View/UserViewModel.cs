namespace DecoupageStore.Web.Areas.Administration.Models.View
{
    using System.Collections.Generic;

    using Infrastructure.Mapping;
    using Services.Data.Models;


    public class UserViewModel : IMapFrom<UserNameRoleModel>
    {
        public string UserName { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}