using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Persistence.DatabaseContext;
using WhatCanICook.Persistence.Repositories;

namespace WhatCanICook.Persistence; 
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<CookDatabaseContext>(options => {
            options.UseMySql(configuration.GetConnectionString("DatabaseConnectionString"), ServerVersion.AutoDetect(
                configuration.GetConnectionString("DatabaseConnectionString")));
            });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();

        return services;
    }
}