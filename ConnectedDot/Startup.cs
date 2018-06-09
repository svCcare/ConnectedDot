using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConnectedDot.Startup))]
namespace ConnectedDot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
