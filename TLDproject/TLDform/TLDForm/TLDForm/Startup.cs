using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TLDForm.Startup))]
namespace TLDForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
