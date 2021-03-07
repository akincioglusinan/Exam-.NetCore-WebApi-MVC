using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SinavProje.Core.Utilities.Security.Authorization;
using SinavProje.Core.Utilities.Security.Authorization.Jwt;

namespace SinavProje.Business.DependencyResolvers.RegisterServices
{
    public static class CoreContainer
    {
        public static void AddScopedCoreServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHelper, JwtTokenHelper>();

        }
        public static void AddJwtTokenOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var databaseSection = configuration.GetSection("TokenOptions");
            serviceCollection.Configure<TokenOptions>(c => databaseSection.Bind(c));
            serviceCollection.AddSingleton<ITokenOptions>(serviceProvider => serviceProvider.GetRequiredService<IOptions<TokenOptions>>().Value);
        }
    }
}
