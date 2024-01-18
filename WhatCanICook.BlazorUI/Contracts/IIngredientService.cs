using WhatCanICook.BlazorUI.Models;
using WhatCanICook.BlazorUI.Services.Base;

namespace WhatCanICook.BlazorUI.Contracts;
public interface IIngredientService {
    Task<List<IngredientVM>> GetIngredientVMs();
    Task<Response<Guid>> CreateIngredient(IngredientVM ingredient);
    Task<Response<Guid>> UpdateIngredient(int id, IngredientVM ingredient);
    Task<Response<Guid>> DeleteIngredient(int id);

}
