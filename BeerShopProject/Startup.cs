using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerShopProject.Startup))]
namespace BeerShopProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
