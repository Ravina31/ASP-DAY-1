using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_CRUDUsingEF.Startup))]
namespace MVC_CRUDUsingEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
