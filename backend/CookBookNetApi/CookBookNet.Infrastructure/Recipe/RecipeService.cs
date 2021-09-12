using CookBookNet.Domain.Interfaces;
using System;
using System.Collections.Generic;


namespace CookBookNet.Infrastructure.Recipe
{
    public class RecipeService : Domain.Interfaces.IRecipeService
    {
        private readonly IRepository<Domain.Recipe> repository;
        private readonly IImageHandlerService imageHandlerService;

        public RecipeService(IRepository<Domain.Recipe> repository, IImageHandlerService imageHandlerService)
        {
            this.repository = repository;
            this.imageHandlerService = imageHandlerService;
        }

        public Domain.Recipe AddRecipe(Domain.Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetAll()
        {
            throw new NotImplementedException();
        }

        public Recipe GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Recipe GetByName()
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipe(Guid id, Domain.Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
