using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pro.Startup))]
namespace Pro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
