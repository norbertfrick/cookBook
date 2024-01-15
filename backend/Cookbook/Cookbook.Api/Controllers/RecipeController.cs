using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public RecipeController(IRecipeService recipeService)
        {
            this._recipeService = recipeService;
        }

        [HttpGet]
        [Route("api/[controller]/recipe")]
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/recipes")]
        public ActionResult GetAll()
        {
            var result = _recipeService.GetAll();

            return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpPatch]
        [Authorize]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Recipe> Create()
        {
            return Ok();
        }
    }
}