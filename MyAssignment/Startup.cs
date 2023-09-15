using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyAssignment.Startup))]
namespace MyAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
