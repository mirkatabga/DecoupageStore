using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DecoupageStore.Web.Startup))]
namespace DecoupageStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
