using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestaurantSystem.ApplicationServices.Components.PasswordHash;
using RestaurantSystemDataAccess;
using RestaurantSystemDataAccess.CQRS.Queries;
using RestaurantSystemDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RestaurantSystem.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHash passwordHash;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IQueryExecutor queryExecutor,
            IPasswordHash passwordHash)
            : base(options, logger, encoder, clock)
        {
            this.queryExecutor = queryExecutor;
            this.passwordHash = passwordHash;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            Employee user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                var query = new GetEmployeeByUsernameQuery()
                {
                    Username = username
                };

                user = await this.queryExecutor.Execute(query);

                if (user == null)
                    return AuthenticateResult.Fail("User does not exist");

                var hashedPassword = passwordHash.HashToCheck(password, user.Salt);
                if (user.Password != hashedPassword)
                {
                    return AuthenticateResult.Fail("Wrong password");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
