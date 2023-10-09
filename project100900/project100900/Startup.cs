using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(project100900.Startup))]
namespace project100900
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
