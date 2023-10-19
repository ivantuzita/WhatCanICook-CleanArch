using AutoMapper;
using WhatCanICook.Application.DTOs;
using WhatCanICook.Application.Exceptions;
using WhatCanICook.Application.Services.Interfaces;
using WhatCanICook.Application.Services.Validators;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.Services;
public class RecipeService : IRecipeService {

    private readonly IGenericRepository<Recipe> _repository;
    private readonly IMapper _mapper;

    public RecipeService(IGenericRepository<Recipe> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(RecipeDTO recipe) {
        RecipeValidator validator = new RecipeValidator();
        var valResult = await validator.ValidateAsync(recipe);

        //if not valid
        if (!valResult.IsValid) {
            throw new BadRequestException("New Recipe is invalid.", valResult);
        }

        var newRecipe = _mapper.Map<Recipe>(recipe);
        await _repository.CreateAsync(newRecipe);
    }

    public async Task DeleteByIdAsync(int id) {
        await DeleteByIdAsync(id);
    }

    public async Task<bool> ExistsById(int id) {
        bool result = await _repository.ExistsById(id);
        return result;
    }

    public async Task UpdateAsync(RecipeDTO recipe) {
        var existingRecipe = await _repository.GetByIdAsync(recipe.Id);

        if (existingRecipe == null) {
            throw new NotFoundException($"Recipe with id {recipe.Id} has not been found.");
        }

        RecipeValidator validator = new RecipeValidator();
        var valResult = await validator.ValidateAsync(recipe);

        //if not valid
        if (!valResult.IsValid) {
            throw new BadRequestException("New Recipe is invalid.", valResult);
        }

        var newRecipe = _mapper.Map<Recipe>(recipe);
        await _repository.UpdateAsync(newRecipe);
    }
}
