using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace ODataPOC.Security
{
    public class AuthenticationMiddleware : OwinMiddleware
    {
        public AuthenticationMiddleware(OwinMiddleware next) :
            base(next)
        {
        }


        public override Task Invoke(IOwinContext context)
        {
            var header = context.Request.Headers.Get("Authorization");


            if (!string.IsNullOrWhiteSpace(header))
            {
                var authHeader = AuthenticationHeaderValue.Parse(header);

                if ("Basic".Equals(authHeader.Scheme,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var parameter = Encoding.UTF8.GetString(
                        Convert.FromBase64String(
                            authHeader.Parameter));
                    var parts = parameter.Split(':');

                    var userName = parts[0];
                    var password = parts[1];

                    if (userName == password)
                        // Just a dumb check ,here you should implement the access to authentication API.
                    {
                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, "Alexey")
                        };
                        var identity = new ClaimsIdentity(claims, "Basic");

                        context.Request.User = new ClaimsPrincipal(identity);
                    }
                }
            }
            else
            {
                var resp = (OwinResponse) context.Response;
                resp.Headers.Set("WWW-Authenticate", "Basic");
            }

            return Next.Invoke(context);
        }
    }
}