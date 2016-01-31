namespace DecoupageStore.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;

    using Models.View;
    using Services.Data.Contracts;

    public class ManageController : Controller
    {
        private readonly IUsersService usersService;

        public ManageController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            IList<UserViewModel> userViewModelsList = usersService.GetUserNameRolesForPage()
                .ProjectTo<UserViewModel>()
                .ToList();

            return View(userViewModelsList);
        }
    }
}