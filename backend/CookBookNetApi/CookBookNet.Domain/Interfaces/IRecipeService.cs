using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Interfaces
{
    public interface IRecipeService
    {
        public Recipe GetById(Guid id);

        public Recipe GetByName();

        public List<Recipe> GetAll();

        public Recipe AddRecipe(Recipe recipe);

        public void DeleteRecipe(Guid id);

        public void UpdateRecipe(Guid id, Recipe recipe);

    }
}
