using Microsoft.Owin;
using ODataPOC;
using ODataPOC.Security;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace ODataPOC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof (AuthenticationMiddleware));
        }
    }
}