using Cookbook.Domain.Interfaces.Repositories;
using Cookbook.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(CookbookDbContext context) 
        {
            _context = context;
        }

        private readonly CookbookDbContext _context;

        public User Create(User entity)
        {
            var result = _context.Users.Add(entity);
            _context.SaveChanges();

            return result.Entity;
        }

        public User Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => string.Equals(u.Email, email));
        }

        public Task<User> GetById(Guid id)
        {
            return _context.Users.FirstOrDefaultAsync(u => string.Equals(u.Id, id));
        }

        public User Update(Guid id, User newObject)
        {
            throw new NotImplementedException();
        }
    }
}
