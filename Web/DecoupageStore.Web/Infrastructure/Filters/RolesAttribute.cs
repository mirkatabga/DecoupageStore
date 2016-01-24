namespace DecoupageStore.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    public class RolesAttribute : AuthorizeAttribute
    {
        private readonly string roles;

        public RolesAttribute(string roles)
        {
            this.roles = roles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //filterContext.RequestContext.HttpContext.User.IsInRole()
            base.OnAuthorization(filterContext);
        }
    }
}