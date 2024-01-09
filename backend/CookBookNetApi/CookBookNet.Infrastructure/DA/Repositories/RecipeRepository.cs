using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using CookBookNet.Infrastructure.DA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.DA.Repositories
{
    public class RecipeRepository : IRepository<Recipe>
    {
        private readonly CookBookDbContext context;

        public RecipeRepository(CookBookDbContext context)
        {
            this.context = context;
        }

        public async Task<Recipe> Create(Recipe entity)
        {
            var entry = await this.context.AddAsync(entity);
            await this.context.SaveChangesAsync();
            
            return entry?.Entity;
        }

        public Recipe Delete(Recipe entity)
        {
            this.context.Recipes.Remove(entity);

            return entity;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return this.context.Recipes.ToList();
        }

        public async Task<Recipe> GetSingle(Guid id)
        {
            return await this.context.Recipes.FindAsync(id);
        }

        public async Task<Recipe> Update(Guid id, Recipe entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Recipe>> GetBySpec(Func<Recipe, bool> spec)
        {
            return this.context.Recipes.Where(spec);
        }
    }
}
