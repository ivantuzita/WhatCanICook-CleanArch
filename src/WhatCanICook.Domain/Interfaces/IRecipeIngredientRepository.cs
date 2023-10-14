using WhatCanICook.Domain.Models;

namespace WhatCanICook.Domain.Interfaces; 
public interface IRecipeIngredientRepository : IGenericRepository<RecipeIngredient> {
    Task<List<Ingredient>> GetIngredientsByRecipe(int recipeId);
    Task<int> GetIngredientQuantity(int ingredientId);
    Task AddIngredientToRecipe(int ingredientId, int recipeId, int quantity);
    Task RemoveIngredientFromRecipe(int ingredientId, int recipeId);
}
