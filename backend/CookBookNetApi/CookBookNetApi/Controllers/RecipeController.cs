using CookBookNetApi.Domains.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookNetApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("recipes")]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<RecipeDto>> GetRecipes()
        {
            var result = new List<RecipeDto>();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<RecipeDto> GetSingle(Guid id)
        {
            var result = new RecipeDto();

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeDto dto)
        {
            var result = new RecipeDto();

            return CreatedAtAction("CreateEmployeeModel", new { id  = "123"}, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(RecipeDto dto)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            return Ok();
        }

        [NonAction]
        public string SaveImage(IFormFile img)
        {
            return "";
        }

    }
}
