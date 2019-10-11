using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using RentAVehicle.API.Providers;
using Swashbuckle.Application;

[assembly: OwinStartup(typeof(RentAVehicle.API.Startup))]

namespace RentAVehicle.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            app.UseCors(CorsOptions.AllowAll);

            ConfigureOAuth(app);

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Rent a Vehicle v1");

            }).EnableSwaggerUi();

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AuthenticationType = "password",
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
