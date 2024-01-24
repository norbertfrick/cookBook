using Cookbook.Domain.Helpers;
using Cookbook.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces.Services
{
    public interface IImageService
    {
        Task<RequestResponse<RecipeImage>> UploadRecipeImage(IFormFile image, Guid recipeId);

        Task<RequestResponse<RecipeImage>> DeleteImage(Guid imageId);
    }
}
