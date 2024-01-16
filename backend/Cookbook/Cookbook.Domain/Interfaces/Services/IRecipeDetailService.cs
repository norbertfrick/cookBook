using Cookbook.Domain.Helpers;
using Cookbook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces
{
    public interface IRecipeDetailService
    {
        public Task<RequestResponse<RecipeDetail>> GetRecipeDetail(Guid recipeId);

        public Task<RequestResponse<RecipeDetail>> UpdateRecipeDetail(Guid detailId, RecipeDetail detail);
    }
}
