using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jiraiya.Startup))]
namespace Jiraiya
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
