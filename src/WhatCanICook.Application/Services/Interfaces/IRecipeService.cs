using WhatCanICook.Application.DTOs;

namespace WhatCanICook.Application.Services.Interfaces; 
public interface IRecipeService {
    Task CreateAsync(RecipeDTO recipe);
    Task UpdateAsync(RecipeDTO recipe);
    Task DeleteByIdAsync(int id);
    Task<bool> ExistsById(int id);
}
