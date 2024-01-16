using Cookbook.Domain.Helpers;
using Cookbook.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces
{
    public interface IRecipeService
    {
        public Task<RequestResponse<Recipe>> CreateRecipe(Recipe recipe, RecipeDetail detail, IFormFile? titleImage = null);

        public Task<RequestResponse<List<Recipe>>> GetAll();

        public Task<RequestResponse<Recipe>> Get(Guid id);

        public Task<RequestResponse<Recipe>> DeleteRecipe(Guid id);

        public Task<RequestResponse<Recipe>> UpdateRecipe(Guid id, Recipe recipe);
    }
}