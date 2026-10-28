using Game.ServiceLayer; 
using Game.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game.ServiceLayer; // MUST BE THIS NAMESPACE

public static class DependencyInjection
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccessLayer(configuration); 

        services.AddScoped<GameService>();
        services.AddScoped<UserService>();

        return services;
    }
}