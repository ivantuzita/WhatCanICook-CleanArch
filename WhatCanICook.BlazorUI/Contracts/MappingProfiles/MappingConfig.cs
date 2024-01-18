using AutoMapper;
using WhatCanICook.BlazorUI.Models;
using WhatCanICook.BlazorUI.Services.Base;

namespace WhatCanICook.BlazorUI.Contracts.MappingProfiles; 
public class MappingConfig : Profile {
    public MappingConfig()
    {
        CreateMap<IngredientDTO, IngredientVM>().ReverseMap();
    }
}
