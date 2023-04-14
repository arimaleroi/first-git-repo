using Credentials.Identity.Models;
using Credentials.Identity.Services;
using IdentityServer4.Models;

namespace Credentials.Identity
{
    internal sealed class Program
    {
        private static IReadOnlyCollection<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource(Scopes.GetUser)
                {
                    Scopes = { Scopes.GetUser }
                },
                new ApiResource(Scopes.UpdateUser)
                {
                    Scopes = { Scopes.UpdateUser }
                }
            };
        }

        private static IReadOnlyCollection<ApiScope> GetApiScope()
        {
            return new[]
            {
                new ApiScope(Scopes.GetUser),
                new ApiScope(Scopes.UpdateUser)
            };
        }


        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder
                .Host
                .UseContentRoot(Directory.GetCurrentDirectory());

            var services = builder.Services;


            services.AddCors();
            services.AddScoped<IUserRepository, MemoryUserRepository>();
            services.AddScoped<IPasswordHasher, SimplePasswordHasher>();

            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            services.AddControllers();

            services
                .AddIdentityServer(
                    options =>
                    {
                        options.Discovery.ShowResponseModes = false;
                        options.Endpoints.EnableAuthorizeEndpoint = false;
                        options.Endpoints.EnableCheckSessionEndpoint = false;
                        options.Endpoints.EnableEndSessionEndpoint = false;
                        options.Endpoints.EnableTokenRevocationEndpoint = false;
                        options.Endpoints.EnableUserInfoEndpoint = false;
                        options.Endpoints.EnableIntrospectionEndpoint = false;
                    })
                .AddDeveloperSigningCredential()
                .AddClientStore<CredentialsStore>()
                .AddSecretValidator<DefaultSecretValidator>()
                //Adds aud array to token
                //.AddInMemoryApiResources(GetApiResources())
                .AddInMemoryApiScopes(GetApiScope());

            WebApplication app =  builder.Build();


            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}