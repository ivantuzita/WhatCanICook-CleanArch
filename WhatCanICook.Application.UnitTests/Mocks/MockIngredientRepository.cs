using Moq;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.UnitTests.Mocks;
public class MockIngredientRepository {
    public static Mock<IGenericRepository<Ingredient>> GetMockIngredientsRepository() {
        var ingredients = new List<Ingredient> {
            new Ingredient {
                Id = 1,
                Name = "test Onion"
            },
            new Ingredient {
                Id = 2,
                Name = "test Tomato"
            },
            new Ingredient {
                Id = 3,
                Name = "test Potato"
            }
        };

        var mockRepo = new Mock<IGenericRepository<Ingredient>>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(ingredients);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Ingredient>()))
            .Returns((Ingredient ing) => {
                ingredients.Add(ing);
                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.ExistsById(It.IsAny<int>()))
            .Returns((int id) => {
                var obj = ingredients.Any(u => u.Id == id);

                if (obj == true) {
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            });

        mockRepo.Setup(r => r.DeleteByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var obj = ingredients.Find(u => u.Id == id);

                if (obj != null) {
                    ingredients.Remove(obj);
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                return Task.FromResult(ingredients.Find(u => u.Id == id));
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Ingredient>()))
            .Returns((Ingredient ing) => {
                var obj = ingredients.Find(u => u.Id == ing.Id);
                if (obj != null) {
                    obj = ing;
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        return mockRepo;
    }

}
