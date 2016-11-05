using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScripturePublishing.Startup))]
namespace ScripturePublishing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
