using CookBookNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> repository;
        private readonly IImageHandlerService imageHandler;

        public RecipeService(IRepository<Recipe> repo, IImageHandlerService imageHandler)
        {
            this.repository = repo;
            this.imageHandler = imageHandler;
        }

        public async Task<Recipe> AddRecipe(Recipe recipe)
        {
            var imagePath = imageHandler.SaveImage(recipe.Image.FileName, recipe.Image);
            recipe.ImagePath = imagePath;
            
            return this.repository.Create(recipe);
        }

        public async Task<Recipe> DeleteRecipe(Guid id)
        {
            var recipe = this.repository.GetSingle(id);
            this.repository.Delete(id);

            return recipe;
        }

        public async Task<List<Recipe>> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public async Task<Recipe> GetById(Guid id)
        {
            return this.repository.GetSingle(id);
        }

        public async Task<Recipe> GetByName()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRecipe(Guid id, Recipe recipe)
        {
            var storedRecipe = this.repository.GetSingle(id);

            if (recipe.ImagePath != storedRecipe.ImagePath)
            {
                //if image names differ, update images and update path to the image
                recipe.ImagePath = this.imageHandler.SaveImage(recipe.Image.FileName, recipe.Image);
            }

            this.repository.Update(id, recipe);
        }


    }
}
