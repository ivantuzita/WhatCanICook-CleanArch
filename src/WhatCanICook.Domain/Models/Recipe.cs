using WhatCanICook.Domain.Models.Common;

namespace WhatCanICook.Domain.Models;
public class Recipe : BaseEntity
{
    public string RecipeContent { get; set; }
    public string PictureURL { get; set; }
}
