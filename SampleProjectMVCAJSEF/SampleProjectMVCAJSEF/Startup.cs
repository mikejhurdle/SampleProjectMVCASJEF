using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleProjectMVCAJSEF.Startup))]
namespace SampleProjectMVCAJSEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
