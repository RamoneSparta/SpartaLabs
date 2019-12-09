using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab26_MVC.Startup))]
namespace Lab26_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
