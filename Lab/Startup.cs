using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab.Startup))]
namespace Lab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
