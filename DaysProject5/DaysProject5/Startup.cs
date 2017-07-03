using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DaysProject5.Startup))]
namespace DaysProject5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
