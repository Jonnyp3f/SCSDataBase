using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCSDataBase.Startup))]
namespace SCSDataBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
