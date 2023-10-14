using AutoMapper;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.MappingProfiles; 
public class IngredientProfile: Profile {
    public IngredientProfile()
    {
        CreateMap<DTOs.IngredientDTO, Ingredient>().ReverseMap();
    }
}
