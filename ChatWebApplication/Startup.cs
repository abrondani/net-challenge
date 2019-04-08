using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatWebApplication.Startup))]
namespace ChatWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
