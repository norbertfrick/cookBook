using Cookbook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces
{
    public interface IRecipeService
    {
        public Recipe CreateRecipe(Recipe recipe, RecipeDetail detail);

        public List<Recipe> GetAll();
    }
}