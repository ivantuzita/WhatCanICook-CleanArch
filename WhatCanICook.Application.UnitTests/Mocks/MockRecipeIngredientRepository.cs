using Moq;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.UnitTests.Mocks;
public class MockRecipeIngredientRepository {
    public static Mock<IRecipeIngredientRepository> GetMockRecipeIngredientsRepository() {
        var recIngs = new List<RecipeIngredient> {
            new RecipeIngredient {
                RecipeId = 1,
                IngredientId = 1,
                Quantity = 3
            },
            new RecipeIngredient {
                RecipeId = 2,
                IngredientId = 2,
                Quantity = 5
            },
            new RecipeIngredient {
                RecipeId = 2,
                IngredientId = 3,
                Quantity = 5
            }
        };

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

        var mockRepo = new Mock<IRecipeIngredientRepository>();

        mockRepo.Setup(r => r.AddIngredientToRecipe(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int ing, int req, int quant) => {
                var obj = new RecipeIngredient { IngredientId = ing, RecipeId = req, Quantity = quant };
                recIngs.Add(obj);
                return Task.CompletedTask;
            });

        //não deveria especificar a receita...?
        mockRepo.Setup(r => r.GetIngredientQuantity(It.IsAny<int>()))
            .Returns((int ingId) => {
                var obj = recIngs.Find(u => u.IngredientId == ingId);
                return Task.FromResult(obj.Quantity);
            });

        mockRepo.Setup(r => r.GetIngredientsByRecipe(It.IsAny<int>()))
            .Returns((int recId) => {
                var recipeIngs = recIngs.Where(q => q.RecipeId == recId).ToList();
                //searches in ingredients table for all Ingredient objects with same Id as recipeIngs list
                var result = ingredients.Where(q => recipeIngs.Any(r => q.Id == r.IngredientId)).ToList();
                return Task.FromResult(result);
            });

        mockRepo.Setup(r => r.RemoveIngredientFromRecipe(It.IsAny<int>(), It.IsAny<int>()))
            .Returns((int ingId, int recId) => {
                var obj = recIngs.Where(q => q.IngredientId == ingId && q.RecipeId == recId).FirstOrDefault();
                recIngs.Remove(obj);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}
