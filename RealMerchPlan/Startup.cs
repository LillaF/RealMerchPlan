using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealMerchPlan.Startup))]
namespace RealMerchPlan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
