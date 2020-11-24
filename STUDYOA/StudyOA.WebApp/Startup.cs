using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyOA.WebApp.Startup))]
namespace StudyOA.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
