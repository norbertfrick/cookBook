using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.DA.Repositories
{
    public class RecipeRepository : IRepository<Recipe>
    {
        public async Task<Recipe> Create(Recipe entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> Update(Guid id, Recipe entity)
        {
            throw new NotImplementedException();
        }
    }
}
