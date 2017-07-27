using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AZMVC_Application.Startup))]
namespace AZMVC_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
