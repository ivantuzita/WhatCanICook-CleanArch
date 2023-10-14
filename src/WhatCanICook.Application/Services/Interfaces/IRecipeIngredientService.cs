using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.Services.Interfaces; 
public interface IRecipeIngredientService {
    Task<List<Ingredient>> GetIngredientsByRecipe(int recipeId);
    Task<int> GetIngredientQuantity(int ingredientId);
    Task AddIngredientToRecipe(int ingredientId, int recipeId, int quantity);
    Task RemoveIngredientFromRecipe(int ingredientId, int recipeId);
}
