using AutoMapper;
using Moq;
using Shouldly;
using WhatCanICook.Application.MappingProfiles;
using WhatCanICook.Application.Services;
using WhatCanICook.Application.DTOs;
using WhatCanICook.Application.UnitTests.Mocks;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;


namespace WhatCanICook.Application.UnitTests.Features.Ingredients; 
public class IngredientServiceTests {

    private readonly Mock<IGenericRepository<Ingredient>> _mockRepo;
    private IMapper _mapper;

    public IngredientServiceTests()
    {
        _mockRepo = MockIngredientRepository.GetMockIngredientsRepository();
        var mapperConfig = new MapperConfiguration(c => {
            c.AddProfile<IngredientProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetIngredientListTest() {
        var _service = new IngredientService(_mockRepo.Object, _mapper);

        var getAll = await _service.GetAllAsync();

        getAll.ShouldBeOfType<List<Ingredient>>();
        getAll.Count.ShouldBe(3);
    }

    [Fact]
    public async Task ExistsByIdTest() {
        var _service = new IngredientService(_mockRepo.Object, _mapper);

        var exists = await _service.ExistsById(3);

        exists.ShouldBeOfType<bool>();
        exists.ShouldBeTrue();
    }

    [Fact]
    public async Task CreateAsyncTest() {
        var _service = new IngredientService(_mockRepo.Object, _mapper);
        var ing = new IngredientDTO { Id = 4, Name = "test Onion" };

        await _service.CreateAsync(ing);
    }

    [Fact]
    public async Task UpdateAsyncTest() {
        var _service = new IngredientService(_mockRepo.Object, _mapper);
        var ing = new IngredientDTO { Id = 1, Name = "test Onion testing" };

        await _service.UpdateAsync(ing);
    }

    [Fact]
    public async Task DeleteByIdTest() {
        var _service = new IngredientService(_mockRepo.Object, _mapper);

        var getAll = await _service.GetAllAsync();

        await _service.DeleteByIdAsync(3);

        getAll.Count.ShouldBe(2);
    }

}
