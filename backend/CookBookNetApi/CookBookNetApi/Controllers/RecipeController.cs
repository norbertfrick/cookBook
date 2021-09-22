using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookNetApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService recipeService;
        private readonly IEntityMapper<RecipeDto, Recipe> mapper;

        public RecipeController(IRecipeService recipeService, IEntityMapper<RecipeDto, Recipe> mapper)
        {
            this.recipeService = recipeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var result = new List<RecipeDto>();

            try
            {
                var recipes = await this.recipeService.GetAll();
                result = recipes.Select(r => mapper.MapToDto(r)).ToList();
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }

            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            try
            {
                var result = await this.recipeService.GetById(id);

                return Ok(this.mapper.MapToDto(result));
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RecipeDto dto)
        {
            try
            {
                var result = this.recipeService.AddRecipe(mapper.MapFromDto(dto));

                return CreatedAtAction("CreateRecipe", new { id = result.Id }, result);
            }

            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]RecipeDto dto)
        {
            try
            {
                await this.recipeService.UpdateRecipe(dto.Id, mapper.MapFromDto(dto));

                return Ok(dto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var entry = this.recipeService.GetById(id);
                var result = await this.recipeService.DeleteRecipe(id);

                return Ok(result);

            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
