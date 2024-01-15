using Cookbook.Domain.Interfaces;
using Cookbook.Domain.Interfaces.Repositories;
using Cookbook.Domain.Interfaces.Services;
using Cookbook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Services
{
    

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeDetailService _detailService;

        public RecipeService(IRecipeRepository repo, IRecipeDetailService detailService)
        {
            this._recipeRepository = repo;
            this._detailService = detailService;
        }

        public Recipe CreateRecipe(Recipe recipe, RecipeDetail detail)
        {
            return null;
        }

        public List<Recipe> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
