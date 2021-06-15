using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineBookStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OnlineBookStore.Security.Basic
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IOnlineBookStoreAuthentication IOnlineBookStoreAuthentication;

        public BasicAuthenticationHandler(
                                      IOptionsMonitor<AuthenticationSchemeOptions> options
                                     , ILoggerFactory logger
                                     , UrlEncoder encoder
                                     , ISystemClock clock
                                     , IOnlineBookStoreAuthentication iOnlineBookStoreAuthentication)
                            : base(options, logger, encoder, clock)
        {
            IOnlineBookStoreAuthentication = iOnlineBookStoreAuthentication;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization")) return AuthenticateResult.Fail("Missing Authorization Header");
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                var authK = await Task.Run(() => IOnlineBookStoreAuthentication.Authenticate(username, password));
                if (!authK)
                    return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, "TestNameIdentifier"),
                new Claim(ClaimTypes.Name, "TestName"),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

    }
}
