using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cookbook.Domain.Model;
using Microsoft.AspNetCore.Authorization;

namespace Cookbook.Api.Controllers
{
    [ApiController]
    [Route("api/recipe/detail")]
    public class RecipeDetailController : ControllerBase
    {
        [HttpGet]
        public ActionResult<RecipeDetail> Get([FromQuery] Guid recipeId)
        {
            RecipeDetail result = new RecipeDetail();
            return Ok(result);
        }

        [HttpPatch]
        [Authorize]
        public ActionResult<RecipeDetail> Update()
        {
            RecipeDetail result = new RecipeDetail();
            return Ok();
        }
    }
}