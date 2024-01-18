using AutoMapper;
using WhatCanICook.BlazorUI.Contracts;
using WhatCanICook.BlazorUI.Models;
using WhatCanICook.BlazorUI.Services.Base;

namespace WhatCanICook.BlazorUI.Services;
public class IngredientService : BaseHttpService, IIngredientService {
    
    private readonly IMapper _mapper;

    public IngredientService(IClient client, IMapper mapper) : base(client) {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> CreateIngredient(IngredientVM ingredient) {
        try {
            var ingredientDTO = _mapper.Map<IngredientDTO>(ingredient);
            await _client.IngredientPOSTAsync(ingredientDTO);
            return new Response<Guid>() {
                Success = true
            };
        }
        catch (ApiException ex) {
            return ConvertApiExceptions<Guid>(ex);
        } 
    }

    public async Task<Response<Guid>> DeleteIngredient(int id) {
        try {
            await _client.IngredientDELETEAsync(id);
            return new Response<Guid>() {
                Success = true
            };
        }
        catch (ApiException ex) {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<IngredientVM>> GetIngredientVMs() {
        var ings = await _client.IngredientAllAsync();
        return _mapper.Map<List<IngredientVM>>(ings);
    }

    public async Task<Response<Guid>> UpdateIngredient(int id, IngredientVM ingredient) {
        try {
            var ingredientDTO = _mapper.Map<IngredientDTO>(ingredient);
            await _client.IngredientPUTAsync(id.ToString(), ingredientDTO);
            return new Response<Guid>() {
                Success = true
            };
        }
        catch (ApiException ex) {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
