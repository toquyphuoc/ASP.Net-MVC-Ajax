using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JQueryStudyTestTheoClip.Startup))]
namespace JQueryStudyTestTheoClip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
