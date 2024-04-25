using Cookbook.Domain.Helpers;
using Cookbook.Domain.Interfaces;
using Cookbook.Domain.Interfaces.Repositories;
using Cookbook.Domain.Interfaces.Services;
using Cookbook.Domain.Model;
using Microsoft.AspNetCore.Http;
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
        private readonly IImageService _imageUploadService;

        public RecipeService(IRecipeRepository repo, IRecipeDetailService detailService, IImageService imageUpload)
        {
            this._recipeRepository = repo;
            this._imageUploadService = imageUpload;
        }

        public async Task<RequestResponse<Recipe>> CreateRecipe(Recipe recipe, RecipeDetail detail, IFormFile? titleImage)
        {
            try
            {
                recipe.Detail = detail;
                var result = _recipeRepository.Create(recipe);

                if (titleImage is null)
                    return new RequestResponse<Recipe>(true, result);

                var uploadedImage = await _imageUploadService.UploadRecipeImage(titleImage, result.Id);

                if (!uploadedImage.IsSuccess)
                    return new RequestResponse<Recipe>(true, result, uploadedImage.Message);

                _recipeRepository.Update(result.Id, result);

                return new RequestResponse<Recipe>(true, result);
            }
            catch (Exception ex)
            {
                return new RequestResponse<Recipe>(false, null, ex.Message);
            }
        }

        public async Task<RequestResponse<Recipe>> DeleteRecipe(Guid id)
        {
            try
            {
                var result = _recipeRepository.Delete(id);
                return new RequestResponse<Recipe>(true, result);
            }
            catch (Exception ex)
            {
                return new RequestResponse<Recipe>(false, null, ex.Message);
            }
        }

        public async Task<RequestResponse<Recipe>> Get(Guid id)
        {
            RequestResponse<Recipe> result = new(true, null);
            try
            {
                var recipe = await _recipeRepository.GetById(id);

                if (recipe.TitleImageId != Guid.Empty)
                {
                    var imageDeletionResult = await _imageUploadService.DeleteImage(recipe.TitleImageId);

                    if (!imageDeletionResult.IsSuccess)
                    {
                        result.IsSuccess = false;
                        result.Message += imageDeletionResult.Message;
                    }
                }
                
                var deletionResult = _recipeRepository.Delete(id);

                return new RequestResponse<Recipe>(true, deletionResult);
            }
            catch (Exception ex)
            {
                return new RequestResponse<Recipe>(false, null, ex.Message);
            }
        }

        public async Task<RequestResponse<List<Recipe>>> GetAll()
        {
            try
            {
                var data = await _recipeRepository.GetAll();

                return new RequestResponse<List<Recipe>>(true, data.ToList());
            }
            catch (Exception ex)
            {
                return new RequestResponse<List<Recipe>>(false, new(), ex.Message);
            }
        }

        public async Task<RequestResponse<Recipe>> UpdateRecipe(Guid id, Recipe recipe)
        {
            try
            {
                var result = _recipeRepository.Update(id, recipe);
                return new RequestResponse<Recipe>(true, result);
            }
            catch (Exception ex)
            {
                return new RequestResponse<Recipe>(false, null, ex.Message);
            }
        }
    }
}
