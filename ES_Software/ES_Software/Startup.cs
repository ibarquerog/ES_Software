using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ES_Software.Startup))]
namespace ES_Software
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
