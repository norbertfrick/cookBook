using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/recipe/notes")]
    public class RecipeNotesController : ControllerBase
    {
        [HttpPost]
        //not sure if necessary
        public ActionResult<RecipeNotes> Get([FromQuery] Guid recipeId, [FromQuery] Guid userId)
        {
            return Ok();
        }

        [HttpPatch]
        public ActionResult<RecipeNotes> Update() // add args
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult<RecipeNotes> Delete()
        {
            return Ok();
        }

    }
}