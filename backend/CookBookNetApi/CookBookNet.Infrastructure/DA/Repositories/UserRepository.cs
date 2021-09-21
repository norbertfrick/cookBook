using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBookNet.Infrastructure.DA.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
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
