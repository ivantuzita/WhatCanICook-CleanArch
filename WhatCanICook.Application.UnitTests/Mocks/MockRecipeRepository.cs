using Moq;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.UnitTests.Mocks;
public class MockRecipeRepository {
    public static Mock<IGenericRepository<Recipe>> GetMockRecipesRepository() {
        var recipes = new List<Recipe> {
            new Recipe {
                Id = 1,
                Name = "Estrogonofe",
                RecipeContent = "Estrogonofe é um prato originário da culinária russa composto de cubos de carne ou legumes, servidos num molho de creme de leite."
            },
            new Recipe {
                Id = 2,
                Name = "Gyūdon",
                RecipeContent = "Gyudon é um prato japonês que consiste em uma tigela de arroz coberta com carne bovina e cebola cozidos em um molho levemente adocicado feito de dashi, shoyu e mirin."
            },
            new Recipe {
                Id = 3,
                Name = "Yakisoba-pan",
                RecipeContent = "Yakisoba-pan é uma comida japonesa popular na qual o yakisoba é colocado entre um rolo de pão branco oblongo que se assemelha a um pão de cachorro-quente."
            }
        };

        var mockRepo = new Mock<IGenericRepository<Recipe>>();

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Recipe>()))
           .Returns((Recipe rec) => {
               recipes.Add(rec);
               return Task.CompletedTask;
           });

        mockRepo.Setup(r => r.ExistsById(It.IsAny<int>()))
            .Returns((int id) => {
                var obj = recipes.Any(u => u.Id == id);

                if (obj == true) {
                    return Task.FromResult(true);
                }
                return Task.FromResult(false);
            });

        mockRepo.Setup(r => r.DeleteByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                var obj = recipes.Find(u => u.Id == id);

                if (obj != null) {
                    recipes.Remove(obj);
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .Returns((int id) => {
                return Task.FromResult(recipes.Find(u => u.Id == id));
            });

        mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Recipe>()))
            .Returns((Recipe rec) => {
                var obj = recipes.Find(u => u.Id == rec.Id);
                if (obj != null) {
                    obj = rec;
                    return Task.CompletedTask;
                }
                //is this correct?
                return Task.FromResult(false);
            });

        return mockRepo;
    }
}
