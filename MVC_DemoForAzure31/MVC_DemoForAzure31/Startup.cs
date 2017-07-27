using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_DemoForAzure31.Startup))]
namespace MVC_DemoForAzure31
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
