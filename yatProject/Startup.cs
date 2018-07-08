using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(yatProject.Startup))]
namespace yatProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
