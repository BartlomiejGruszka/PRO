using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRO.Startup))]
namespace PRO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
