using Microsoft.AspNetCore.Mvc;
using WhatCanICook.Application.DTOs;
using WhatCanICook.Application.Services.Interfaces;

namespace WhatCanICook.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase {

        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // POST api/<RecipeController>
        [HttpPost("")]
        public async Task<ActionResult> CreateAsync([FromBody] RecipeDTO rec) {
            await _recipeService.CreateAsync(rec);
            return Ok();
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] RecipeDTO rec) {
            await _recipeService.UpdateAsync(rec);
            return Ok();
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id) {
            await _recipeService.DeleteByIdAsync(id);
            return Ok();
        }

    }
}
