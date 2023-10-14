using WhatCanICook.Application.DTOs;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.Services.Interfaces; 
public interface IIngredientService {
    //to display all available ingredients in database
    Task<List<Ingredient>> GetAllAsync();
    Task CreateAsync(IngredientDTO ingredient);
    Task UpdateAsync(IngredientDTO ingredient);
    Task DeleteByIdAsync(int id);
    Task<bool> ExistsById(int id);
}
