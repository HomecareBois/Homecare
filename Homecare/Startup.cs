using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homecare.Startup))]
namespace Homecare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
