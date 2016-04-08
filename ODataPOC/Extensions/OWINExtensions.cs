using System;
using System.Linq;
using System.Web.Routing;
using Microsoft.Owin;

namespace ODataPOC.Extensions
{
    public static class OwinContextExtensions
    {
        public static string GetRouteValue(this IOwinContext context, string key)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (context.Request.Environment.Keys.Contains("System.Web.Routing.RequestContext"))
            {
                var data =
                    ((RequestContext)context.Request.Environment["System.Web.Routing.RequestContext"]).RouteData;
                return data.Values.Keys.Contains(key) ? data.Values[key].ToString() : string.Empty;
            }
            return string.Empty;
        }
    }
}