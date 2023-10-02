using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(project100207.Startup))]
namespace project100207
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
