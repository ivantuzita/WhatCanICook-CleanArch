using FluentValidation;
using WhatCanICook.Application.DTOs;

namespace WhatCanICook.Application.Services.Validators; 
public class RecipeValidator : AbstractValidator<RecipeDTO>{
    public RecipeValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is required!")
            .NotNull()
            .MaximumLength(35).WithMessage("Number of characters on {Name} cannot be bigger than 35!");

        RuleFor(p => p.RecipeContent)
            .NotEmpty().WithMessage("{RecipeContent} is required!")
            .NotNull();
    }
}
