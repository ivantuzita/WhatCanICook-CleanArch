using AutoMapper;
using Moq;
using Shouldly;
using WhatCanICook.Application.DTOs;
using WhatCanICook.Application.Services;
using WhatCanICook.Application.UnitTests.Mocks;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.UnitTests.Features.RecipeIngredients; 
public class RecipeIngredientServiceTests {

    private readonly Mock<IRecipeIngredientRepository> _mockRepo;
    private readonly Mock<IGenericRepository<Recipe>> _mockRepoRec;
    private readonly Mock<IGenericRepository<Ingredient>> _mockRepoIng;

    public RecipeIngredientServiceTests() {
        _mockRepo = MockRecipeIngredientRepository.GetMockRecipeIngredientsRepository();
        _mockRepoRec = MockRecipeRepository.GetMockRecipesRepository();
        _mockRepoIng = MockIngredientRepository.GetMockIngredientsRepository();
    }

    [Fact]
    public async Task AddIngredientToRecipe() {
        var _service = new RecipeIngredientService(_mockRepo.Object, _mockRepoRec.Object, _mockRepoIng.Object);

        await _service.AddIngredientToRecipe(2, 1, 4);
    }

    [Fact]
    public async Task GetIngredientQuantity() {
        var _service = new RecipeIngredientService(_mockRepo.Object, _mockRepoRec.Object, _mockRepoIng.Object);

        var result = await _service.GetIngredientQuantity(2);

        result.ShouldBe(5);
    }

    [Fact]
    public async Task GetIngredientsByRecipe() {
        var _service = new RecipeIngredientService(_mockRepo.Object, _mockRepoRec.Object, _mockRepoIng.Object);

        var result = await _service.GetIngredientsByRecipe(2);

        result.Count.ShouldBe(2);
    }

    [Fact]
    public async Task RemoveIngredientFromRecipe() {
        var _service = new RecipeIngredientService(_mockRepo.Object, _mockRepoRec.Object, _mockRepoIng.Object);

        await _service.RemoveIngredientFromRecipe(2, 2);
    }
}
