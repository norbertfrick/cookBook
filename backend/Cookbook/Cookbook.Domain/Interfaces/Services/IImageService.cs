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
        Task<RecipeImage> UploadRecipeImage(IFormFile image, Guid recipeId);
    }
}
