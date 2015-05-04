using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marquite.Test.Startup))]
namespace Marquite.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
