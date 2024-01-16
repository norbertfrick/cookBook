using Cookbook.Api.Helpers;
using Cookbook.Api.Requests;
using Cookbook.Domain.Interfaces;
using Cookbook.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeDetailService _recipeDetailService;

        public RecipeController(IRecipeService recipeService, IRecipeDetailService detailService)
        {
            this._recipeService = recipeService;
            this._recipeDetailService = detailService;
        }

        [HttpGet]
        [Route("api/[controller]/{:id}")]
        public async Task<ActionResult> Get(Guid id)
            => (await _recipeService.Get(id)).ToRequestResponse();

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ActionResult> GetAll()
            => (await _recipeService.GetAll()).ToRequestResponse();

        [HttpGet]
        [Route("api/[controller]/{:id}/detail")]
        public async Task<ActionResult> GetRecipeDetail(Guid id)
            => (await _recipeDetailService.GetRecipeDetail(id)).ToRequestResponse();

        [HttpPut]
        [Route("api/[controller]/{:id}/detail")]
        public async Task<ActionResult> UpdateRecipeDetail([FromBody] RecipeDetail detail)
            => (await _recipeDetailService.UpdateRecipeDetail(detail.Id, detail)).ToRequestResponse();

        [HttpDelete]
        [Authorize]
        [Route("api/[controller]/{:id}")]
        public async Task<ActionResult> Delete(Guid id)
            => (await _recipeService.DeleteRecipe(id)).ToRequestResponse();

        [HttpPut]
        [Authorize]
        [Route("api/[controller]/{:id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] Recipe recipe) 
            => (await _recipeService.UpdateRecipe(id, recipe)).ToRequestResponse();

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] CreateRecipeRequest request)
        {
            var recipe = new Recipe
            {
                Title = request.Title,
                Description = request.Description,
                OwnerId = request.UserdId,
                Categories = request.Categories,
            };

            

            var detail = new RecipeDetail
            {
                Ingredients = request.Ingredients,
                NumberOfPortions = request.NumberOfPortions,
                Steps = request.Steps,
            };

            var response = await _recipeService.CreateRecipe(recipe, detail, request.TitleImage);

            return response.ToRequestResponse();
        }
    }
}