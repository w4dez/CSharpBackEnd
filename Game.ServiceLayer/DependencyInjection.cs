using Game.ServiceLayer; 
using Game.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Game.ServiceLayer; // MUST BE THIS NAMESPACE

public static class DependencyInjection
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Call the DataAccess method (which lives in the DataAccess project)
        services.AddDataAccessLayer(configuration); 

        // 2. Register the Services
        services.AddScoped<GameService>();

        return services;
    }
}