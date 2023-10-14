using AutoMapper;
using WhatCanICook.Application.DTOs;
using WhatCanICook.Application.Services.Interfaces;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.Services;
public class IngredientService : IIngredientService {

    private readonly IGenericRepository<Ingredient> _repository;
    private readonly IMapper _mapper;

    public IngredientService(IGenericRepository<Ingredient> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(IngredientDTO ingredient) {
        //validação e afins
        var newIngredient = _mapper.Map<Ingredient>(ingredient);
        await _repository.CreateAsync(newIngredient);
    }

    public async Task DeleteByIdAsync(int id) {
        await _repository.DeleteByIdAsync(id);
    }

    public async Task<bool> ExistsById(int id) {
        bool result = await _repository.ExistsById(id);
        return result;
    }

    public async Task<List<Ingredient>> GetAllAsync() {
        var result = await _repository.GetAllAsync();

        if (result == null ) {
            throw new Exception("No ingredients found.");
        }

        return result;
    }

    public async Task UpdateAsync(IngredientDTO ingredient) {
        var newIngredient = _mapper.Map<Ingredient>(ingredient);
        await _repository.UpdateAsync(newIngredient);
    }
}
