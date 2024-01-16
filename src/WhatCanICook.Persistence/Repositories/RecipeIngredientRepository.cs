using Microsoft.EntityFrameworkCore;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;
using WhatCanICook.Persistence.DatabaseContext;

namespace WhatCanICook.Persistence.Repositories
{
    public class RecipeIngredientRepository : RecipeIngredient, IRecipeIngredientRepository
    {
        private readonly CookDatabaseContext _context;

        public RecipeIngredientRepository(CookDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddIngredientToRecipe(int ingredientId, int recipeId, int quantity)
        {
            var obj = new RecipeIngredient {IngredientId = ingredientId, RecipeId = recipeId, Quantity = quantity};
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetIngredientQuantity(int ingredientId)
        {
            var obj = await _context.RecipeIngredients.FindAsync(ingredientId);
            return obj.Quantity;
        }

        public async Task<List<Ingredient>> GetIngredientsByRecipe(int recipeId)
        {
            //gets all recipeIngredients objects with id {recipeId} (gets all ingredientIds from RecipeId)
            var recipeIngs = await _context.RecipeIngredients.Where(q => q.RecipeId == recipeId).ToListAsync();
            //searches in ingredients table for all Ingredient objects with same Id as recipeIngs list
            var result = await _context.Ingredients.Where(q => recipeIngs.Any(r => q.Id == r.IngredientId)).ToListAsync();
            return result;
        }

        public async Task RemoveIngredientFromRecipe(int ingredientId, int recipeId)
        {
            var obj = await _context.RecipeIngredients.Where(q => q.IngredientId == ingredientId
            && q.RecipeId == recipeId).FirstOrDefaultAsync();

            if (obj != null) {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}