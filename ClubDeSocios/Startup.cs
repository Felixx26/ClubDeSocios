using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClubDeSocios.Startup))]
namespace ClubDeSocios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
