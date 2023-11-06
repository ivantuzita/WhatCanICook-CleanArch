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
            options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString"));
            });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}