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
    using Newtonsoft.Json;

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

            this.ViewBag.PagesCount = usersService.GetPagesCount();

            return this.PartialView("_ListUsersPartial", userViewModelsList);
        }

        [HttpGet]
        public ActionResult Search(string query)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<UserViewModel> userViewModelsList = usersService.GetUserNameRolesForPage(query)
                .ProjectTo<UserViewModel>()
                .ToList();

            this.ViewBag.PagesCount = usersService.GetPagesCount(query);

            return PartialView("_ListUsersPartial", userViewModelsList);
        }

        [HttpGet]
        public ActionResult Suggestions(string query)
        {
            if (!this.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<string> usernames = usersService.GetSuggestions(query);

            this.ViewBag.PagesCount = 1;

            return PartialView("_SearchSuggestionsPartial", usernames);
        }
    }
}