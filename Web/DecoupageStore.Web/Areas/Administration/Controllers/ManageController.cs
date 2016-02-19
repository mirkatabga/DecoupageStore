namespace DecoupageStore.Web.Areas.Administration.Controllers
{
    using System.Net;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;

    using Models.View;
    using Services.Data.Contracts;
    using Common.Constants;

    [Authorize(Roles = "Admin")]
    public class ManageController : Controller
    {
        private readonly IUsersService usersService;

        public ManageController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        
        public ActionResult Users(int page = 0, int count = 30)
        {
            IList<UserViewModel> userViewModelsList = usersService.GetUserNameRolesForPage(page,count)
                .ProjectTo<UserViewModel>()
                .ToList();

            this.ViewBag.PagesCount = usersService.GetPagesCount();

            return View(userViewModelsList);
        }

        public ActionResult ListUsers(int page = GlobalConstants.defaultPageNumber,
            int count = GlobalConstants.defaultItemsPerPage)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IList<UserViewModel> userViewModelsList = usersService.GetUserNameRolesForPage(page, count)
                .ProjectTo<UserViewModel>()
                .ToList();

            return this.PartialView("_ListUsersPartial", userViewModelsList);
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<string> userNamesFound = usersService.SearchUser(query);

            return PartialView("_SearchUserNamesPartial", userNamesFound);
        }
    }
}