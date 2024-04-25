using Cookbook.Domain.Helpers;
using Cookbook.Domain.Interfaces.Repositories;
using Cookbook.Domain.Interfaces.Services;
using Cookbook.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Cookbook.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private const string RECIPE_IMAGE_SETTING_CONST = "RecipeImagesPath";

        private readonly IConfiguration _configuration;

        private readonly IRecipeImageRepository _recipeImageRepository;

        public ImageService(IConfiguration config, IRecipeImageRepository imageRepo, IRecipeImageRepository recipeImageRepository)
        {
            _configuration = config;
            _recipeImageRepository = recipeImageRepository;
        }

        public async Task<RequestResponse<RecipeImage>> DeleteImage(Guid imageId)
        {
            var imageData = await _recipeImageRepository.GetById(imageId);

            if (imageData is null)
                return new RequestResponse<RecipeImage>(true, null);

            if (!DeleteImage(imageData.FilePath))
                return new RequestResponse<RecipeImage>(false, null, "Image deletion failed.");

            _recipeImageRepository.Delete(imageId);

            return new RequestResponse<RecipeImage>(true, imageData);

        }

        public async Task<RequestResponse<RecipeImage>> UploadRecipeImage(IFormFile image, Guid recipeId)
        {
            var storagePath = _configuration.GetSection(RECIPE_IMAGE_SETTING_CONST).Value;
            var recipeImage = CreateRecipeImage(image.FileName, storagePath, recipeId);

            var result = _recipeImageRepository.Create(recipeImage);

            var imageSave = await SaveImageToStorage(image, result);

            if (imageSave)
                return new RequestResponse<RecipeImage>(true, result);
            else return new RequestResponse<RecipeImage>(false, null, "Image upload failed.");  // error localization?

        }

        private RecipeImage CreateRecipeImage(string filename, string storagePath, Guid recipeId)
        {
            var id = Guid.NewGuid();
            var uploadedImage = new RecipeImage
            {
                RecipeId = recipeId,
                Id = id,
                FilePath = Path.Combine(storagePath, id.ToString() + Path.GetExtension(filename))
            };

            return uploadedImage;

        }

        private async Task<bool> SaveImageToStorage(IFormFile image, UploadedImage data)
        {
            try
            {
                if (!Directory.Exists(data.FilePath))
                    Directory.CreateDirectory(data.FilePath);

                using var stream = new FileStream(data.FilePath, FileMode.CreateNew);
                await image.CopyToAsync(stream);
                await stream.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool DeleteImage(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
