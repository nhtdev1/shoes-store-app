using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoesStore.Startup))]
namespace ShoesStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
