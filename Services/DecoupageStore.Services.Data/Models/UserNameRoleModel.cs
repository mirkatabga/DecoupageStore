namespace DecoupageStore.Services.Data.Models
{
    using System.Collections.Generic;

    public class UserNameRoleModel
    {
        public string UserName { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
