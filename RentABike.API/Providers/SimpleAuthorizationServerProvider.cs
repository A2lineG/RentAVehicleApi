using System.Linq;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using RentAVehicle.BL.Manager;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace RentAVehicle.API.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuthManager _authManager = new AuthManager())
            {
                IdentityUser user = await _authManager.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                // Get client info
                var clientManager = new ClientManager();

                var client = clientManager.GetClientByMail(user.UserName);
                if (client != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Email, client.Email));
                    identity.AddClaim(new Claim(ClaimTypes.Surname, $"{client.FirstName} {client.Surname}"));
                }

                identity.AddClaims(_authManager.GetUserRoles(user).Select(x => new Claim(ClaimTypes.Role, x)));

                context.Validated(identity);
            }
        }
    }
}