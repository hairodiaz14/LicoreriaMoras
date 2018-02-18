using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LicoreriaMoras.Startup))]
namespace LicoreriaMoras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
