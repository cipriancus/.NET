using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(onlineGrades.MVC.Startup))]
namespace onlineGrades.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
