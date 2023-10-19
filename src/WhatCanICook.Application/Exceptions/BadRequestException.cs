using FluentValidation.Results;

namespace WhatCanICook.Application.Exceptions; 
public class BadRequestException : Exception {
    private List<string> ValidationErrors { get; set; }
    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, ValidationResult valResult): base(message)
    {
        ValidationErrors = new();
        foreach (var error in valResult.Errors) {
            ValidationErrors.Add(error.ErrorMessage);
        }
    }

}
