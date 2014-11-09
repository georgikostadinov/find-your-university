using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindYourUniversity.Web.Startup))]
namespace FindYourUniversity.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
