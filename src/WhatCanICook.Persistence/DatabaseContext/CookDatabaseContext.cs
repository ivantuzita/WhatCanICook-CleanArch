using Microsoft.EntityFrameworkCore;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Persistence.DatabaseContext; 
public class CookDatabaseContext : DbContext {
    public CookDatabaseContext(DbContextOptions<CookDatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CookDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
