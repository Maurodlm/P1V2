using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCS.Startup))]
namespace MVCS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
