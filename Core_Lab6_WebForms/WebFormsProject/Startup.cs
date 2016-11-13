using Microsoft.Owin;
using Owin;
using WebFormsProject;

[assembly: OwinStartup(typeof(Startup))]

namespace WebFormsProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}