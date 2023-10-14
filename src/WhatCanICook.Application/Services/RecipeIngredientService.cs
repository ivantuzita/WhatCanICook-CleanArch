using AutoMapper;
using WhatCanICook.Application.Services.Interfaces;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.Services;
public class RecipeIngredientService : IRecipeIngredientService {

    private readonly IRecipeIngredientRepository _recipeIngredientRepository;
    //private readonly IGenericRepository<Recipe> _recipeRepository;
    //private readonly IGenericRepository<Ingredient> _ingredientRepository;

    public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository
        //IGenericRepository<Recipe> recipeRepository,
        //IGenericRepository<Ingredient> ingredientRepository
        ) {
        _recipeIngredientRepository = recipeIngredientRepository;
        //_recipeRepository = recipeRepository;
        //_ingredientRepository = ingredientRepository;
    }

    public async Task AddIngredientToRecipe(int ingredientId, int recipeId, int quantity) {
        //validations and such
        await _recipeIngredientRepository.AddIngredientToRecipe(ingredientId, recipeId, quantity);
    }

    public async Task<int> GetIngredientQuantity(int ingredientId) {
        var result = await _recipeIngredientRepository.GetIngredientQuantity(ingredientId);
        return result;
    }

    public async Task<List<Ingredient>> GetIngredientsByRecipe(int recipeId) {
        var result = await _recipeIngredientRepository.GetIngredientsByRecipe(recipeId);
        return result;
    }

    public async Task RemoveIngredientFromRecipe(int ingredientId, int recipeId) {
        await _recipeIngredientRepository.RemoveIngredientFromRecipe(ingredientId, recipeId);
    }
}
