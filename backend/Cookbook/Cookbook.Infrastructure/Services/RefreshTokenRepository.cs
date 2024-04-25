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
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly CookbookDbContext _context;
        public RefreshTokenRepository(CookbookDbContext context) 
        {
            _context = context;
        }
        public async Task<UserRefreshToken> Create(UserRefreshToken entity)
        {
            var result = _context.RefreshTokens.Add(entity);

            _context.SaveChanges();

            return result.Entity;
        }

        public Task<UserRefreshToken> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRefreshToken>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserRefreshToken> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRefreshToken> GetByTokenValue(string token)
        {
            return _context.RefreshTokens.FirstOrDefaultAsync(t => t.RefreshToken == token);
        }

        public Task<UserRefreshToken> Update(Guid id, UserRefreshToken newObject)
        {
            throw new NotImplementedException();
        }
    }
}
