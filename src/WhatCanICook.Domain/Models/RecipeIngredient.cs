using Microsoft.EntityFrameworkCore;

namespace WhatCanICook.Domain.Models;
[Keyless]
public class RecipeIngredient
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public int Quantity { get; set; }
}
