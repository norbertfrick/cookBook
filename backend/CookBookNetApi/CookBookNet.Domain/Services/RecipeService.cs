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
            if (recipe.Image != null)
                recipe.ImagePath = imageHandler.SaveImage(recipe.Image.FileName, recipe.Image);
            
            return await this.repository.Create(recipe);
        }

        public async Task<Recipe> DeleteRecipe(Guid id)
        {
            var entity = await this.repository.GetSingle(id);

            if (entity is null) return null;


            this.repository.Delete(entity);

            return entity;
        }

        public async Task<List<Recipe>> GetAll()
        {
            var recipes = this.repository.GetAll();
            return recipes.ToList();
        }

        public async Task<Recipe> GetById(Guid id)
        {
            return await this.repository.GetSingle(id);
        }

        public async Task<Recipe> GetByName()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRecipe(Guid id, Recipe recipe)
        {
            var storedRecipe = await this.repository.GetSingle(id);

            if (recipe.ImagePath != storedRecipe.ImagePath)
            {
                //if image names differ, update images and update path to the image
                recipe.ImagePath = this.imageHandler.SaveImage(recipe.Image.FileName, recipe.Image);
            }

            await this.repository.Update(id, recipe);
        }


    }
}
