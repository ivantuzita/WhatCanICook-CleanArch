using FluentValidation;
using WhatCanICook.Application.DTOs;

namespace WhatCanICook.Application.Services.Validators; 
public class IngredientValidator: AbstractValidator<IngredientDTO> {
    public IngredientValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is required!")
            .NotNull()
            .MaximumLength(35).WithMessage("Number of characters on {Name} cannot be bigger than 35!");
    }
}
