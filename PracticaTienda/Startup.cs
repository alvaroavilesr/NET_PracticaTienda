using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticaTienda.Startup))]
namespace PracticaTienda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
