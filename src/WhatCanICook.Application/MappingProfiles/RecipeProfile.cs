using AutoMapper;
using WhatCanICook.Domain.Models;

namespace WhatCanICook.Application.MappingProfiles; 
public class RecipeProfile: Profile {
    public RecipeProfile()
    {
        CreateMap<DTOs.RecipeDTO, Recipe>().ReverseMap();
    }
}
