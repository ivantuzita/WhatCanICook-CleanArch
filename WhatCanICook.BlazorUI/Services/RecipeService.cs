using WhatCanICook.BlazorUI.Contracts;
using WhatCanICook.BlazorUI.Services.Base;

namespace WhatCanICook.BlazorUI.Services;

public class RecipeService : BaseHttpService, IRecipeService {
    public RecipeService(IClient client) : base(client) {

    }
}
