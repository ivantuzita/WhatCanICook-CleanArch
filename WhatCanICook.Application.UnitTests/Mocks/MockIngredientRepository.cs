﻿using Moq;
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
            .ReturnsAsync((int id) => {
                var obj = ingredients.Any(u => u.Id == id);

                if (obj == true) {
                    return true;
                }
                return false;
            });

        return mockRepo;
    }

}