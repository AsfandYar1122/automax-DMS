using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoMax.Startup))]
namespace AutoMax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
 