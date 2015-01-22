using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cobwebs.Startup))]
namespace Cobwebs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
