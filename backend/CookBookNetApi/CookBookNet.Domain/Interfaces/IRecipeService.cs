using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Interfaces
{
    public interface IRecipeService
    {
        public  Task<Recipe> GetById(Guid id);

        public  Task<Recipe> GetByName();

        public  Task<List<Recipe>> GetAll();

        public  Task<Recipe> AddRecipe(Recipe recipe);

        public  Task<Recipe> DeleteRecipe(Guid id);

        public  Task UpdateRecipe(Guid id, Recipe recipe);

    }
}
