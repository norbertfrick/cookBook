using Cookbook.Domain.Interfaces.Repositories;
using Cookbook.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Infrastructure.Services
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly CookbookDbContext _context;
        public RefreshTokenRepository(CookbookDbContext context) 
        {
            _context = context;
        }
        public UserRefreshToken Create(UserRefreshToken entity)
        {
            var result = _context.RefreshTokens.Add(entity);

            _context.SaveChanges();

            return result.Entity;
        }

        public UserRefreshToken Delete(Guid id)
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

        public UserRefreshToken Update(Guid id, UserRefreshToken newObject)
        {
            throw new NotImplementedException();
        }
    }
}
