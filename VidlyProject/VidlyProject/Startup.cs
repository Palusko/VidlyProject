using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyProject.Startup))]
namespace VidlyProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
