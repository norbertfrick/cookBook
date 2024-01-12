using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Domain.Model;

namespace Cookbook.Domain.Interfaces
{
    public interface IUserService
    {
        User GetUser(Guid id);

        User CreateUser(string username, string password);

        User DeleteUser(Guid userId);

        User UpdateRefreshToken(Guid userId, string refreshToken);

        User ChangePassword(Guid userId, string password);
    }
}