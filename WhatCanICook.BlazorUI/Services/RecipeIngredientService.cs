using WhatCanICook.BlazorUI.Contracts;
using WhatCanICook.BlazorUI.Services.Base;

namespace WhatCanICook.BlazorUI.Services;

public class RecipeIngredientService : BaseHttpService, IRecipeIngredientService {
    public RecipeIngredientService(IClient client) : base(client) {

    }
}
