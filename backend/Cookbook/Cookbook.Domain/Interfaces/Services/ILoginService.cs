using Cookbook.Domain.DTO;
using Cookbook.Domain.Helpers;
using Cookbook.Domain.Model;
using Cookbook.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces
{
    public interface ILoginService
    {
        public Task<RequestResponse<TokenWrapper>> Login(string email, string password);

        public Task<RequestResponse<string>> Logout(Guid userId);

        public Task<RequestResponse<Nullable<Guid>>> RegisterUser(string username, string password);

        public Task<RequestResponse<TokenWrapper>> RefreshToken(string refreshToken);
    }
}