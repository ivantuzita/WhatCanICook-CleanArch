using Microsoft.AspNetCore.Mvc;
using WhatCanICook.Application.DTOs;
using WhatCanICook.Application.Services;
using WhatCanICook.Application.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhatCanICook.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase {

        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService)
        {
            _recipeIngredientService = recipeIngredientService;
        }

        // GET: api/<RecipeIngredientController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<IngredientDTO>>> GetIngredientsByRecipe([FromRoute] int id) {
            var result = await _recipeIngredientService.GetIngredientsByRecipe(id);
            return Ok(result);
        }

        // GET api/<RecipeIngredientController>/quantity/id
        [HttpGet("quantity/{id}")]
        public async Task<ActionResult<int>> GetIngredientQuantity([FromRoute] int id) {
            var result = await _recipeIngredientService.GetIngredientQuantity(id);
            return Ok(result);
        }

        // POST api/<RecipeIngredientController>/add/{ingredientId}/{recipeId}/{quantity}
        [HttpPost("add/{ingredientId}/{recipeId}/{quantity}")]
        public async Task<ActionResult> AddIngredientToRecipe([FromRoute] int ingredientId, int recipeId, int quantity) {
            await _recipeIngredientService.AddIngredientToRecipe(ingredientId, recipeId, quantity);
            return Ok();
        }

        // POST api/<RecipeIngredientController>/remove/{ingredientId}/{recipeId}
        [HttpPost("remove/{ingredientId}/{recipeId}")]
        public async Task<ActionResult> RemoveIngredientFromRecipe([FromRoute] int ingredientId, int recipeId) {
            await _recipeIngredientService.RemoveIngredientFromRecipe(ingredientId, recipeId);
            return Ok();
        }

    }
}
