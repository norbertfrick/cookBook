using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using CookBookNet.Infrastructure.DA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.DA.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly CookBookDbContext context;

        public UserRepository(CookBookDbContext context)
        {
            this.context = context;
        }

        public async Task<User> Create(User entity)
        {
            var user = await this.context.AddAsync(entity);

            await this.context.SaveChangesAsync();

            return user.Entity;

        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return this.context.Users.ToList();
        }

        public Task<User> GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(Guid id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
