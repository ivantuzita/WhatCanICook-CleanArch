using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WhatCanICook.Application.Services;
using WhatCanICook.Application.Services.Interfaces;

namespace WhatCanICook.Application; 
public static class ApplicationServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();

        return services;
    }
}
