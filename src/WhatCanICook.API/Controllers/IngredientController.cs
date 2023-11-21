using Microsoft.AspNetCore.Mvc;
using WhatCanICook.Application.DTOs;
using WhatCanICook.Application.Services.Interfaces;

namespace WhatCanICook.API.Controllers; 
[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase {

    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    // GET: api/<IngredientController>
    [HttpGet("")]
    public async Task<ActionResult<List<IngredientDTO>>> GetAllAsync() {
        var result = await _ingredientService.GetAllAsync();
        return Ok(result);
    }

    // POST api/<IngredientController>
    [HttpPost("")]
    public async Task<ActionResult> CreateAsync([FromBody] IngredientDTO ing) {
        await _ingredientService.CreateAsync(ing);
        return Ok();
    }

    // PUT api/<IngredientController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync([FromBody] IngredientDTO ing) {
        await _ingredientService.UpdateAsync(ing);
        return Ok();
    }

    // DELETE api/<IngredientController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id) {
        await _ingredientService.DeleteByIdAsync(id);
        return Ok();
    }
}
