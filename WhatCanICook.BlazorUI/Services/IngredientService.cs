using WhatCanICook.BlazorUI.Contracts;
using WhatCanICook.BlazorUI.Services.Base;

namespace WhatCanICook.BlazorUI.Services;
public class IngredientService : BaseHttpService, IIngredientService {
    public IngredientService(IClient client) : base(client) {

    }
}
