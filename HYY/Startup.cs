using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HYY.Startup))]
namespace HYY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
