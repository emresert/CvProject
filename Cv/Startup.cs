using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cv.Startup))]
namespace Cv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
