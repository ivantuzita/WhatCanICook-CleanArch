using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;
using WhatCanICook.Persistence.DatabaseContext;

namespace WhatCanICook.Persistence.Repositories
{
    public class RecipeIngredientRepository : GenericRepository<RecipeIngredient>, IRecipeIngredientRepository
    {
        protected readonly CookDatabaseContext _context;

        public RecipeIngredientRepository(CookDatabaseContext context): base(context)
        {
            _context = context;
        }

        public Task AddIngredientToRecipe(int ingredientId, int recipeId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetIngredientQuantity(int ingredientId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ingredient>> GetIngredientsByRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveIngredientFromRecipe(int ingredientId, int recipeId)
        {
            throw new NotImplementedException();
        }
    }
}