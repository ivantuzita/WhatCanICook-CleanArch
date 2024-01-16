using AutoMapper;
using Moq;
using Shouldly;
using WhatCanICook.Application.DTOs;
using WhatCanICook.Application.MappingProfiles;
using WhatCanICook.Application.Services;
using WhatCanICook.Application.UnitTests.Mocks;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.UnitTests.Features.Recipes; 
public class RecipeServiceTests {

    private readonly Mock<IGenericRepository<Recipe>> _mockRepo;
    private IMapper _mapper;

    public RecipeServiceTests()
    {
        _mockRepo = MockRecipeRepository.GetMockRecipesRepository();
        var mapperConfig = new MapperConfiguration(c => {
            c.AddProfile<RecipeProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task ExistsByIdTest() {
        var _service = new RecipeService(_mockRepo.Object, _mapper);

        var exists = await _service.ExistsById(3);

        exists.ShouldBeOfType<bool>();
        exists.ShouldBeTrue();
    }

    [Fact]
    public async Task CreateAsyncTest() {
        var _service = new RecipeService(_mockRepo.Object, _mapper);
        var rec = new RecipeDTO { Id = 4, Name = "Katsu Sando", RecipeContent = "É um clássico nas ruas de Tóquio, a união do tonkatsu, o filé de porco empanado em farinha japonesa de pão, a panko, com um pão de fôrma branco." };

        await _service.CreateAsync(rec);
    }
    
    [Fact]
    public async Task UpdateAsyncTest() {
        var _service = new RecipeService(_mockRepo.Object, _mapper);
        var rec = new RecipeDTO { Id = 1, Name = "Strogonoff", RecipeContent = "Testingggggg"};

        await _service.UpdateAsync(rec);
    }

    [Fact]
    public async Task DeleteByIdTest() {
        var _service = new RecipeService(_mockRepo.Object, _mapper);

        await _service.DeleteByIdAsync(3);
    }
}
