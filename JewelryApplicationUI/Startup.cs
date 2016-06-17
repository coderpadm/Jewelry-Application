using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JewelryApplicationUI.Startup))]
namespace JewelryApplicationUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
