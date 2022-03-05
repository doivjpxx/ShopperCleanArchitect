using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Shop.ApplicationCore.Interfaces;
using Shop.Infrastructure.Persistence.Repositories;

namespace Shop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ShopContext>(options => options.UseNpgsql(defaultConnectionString));

        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}