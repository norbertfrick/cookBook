using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Domain.Model;

namespace Cookbook.Domain.Interfaces
{
    public interface IUserProfileService
    {
        UserProfile GetUserProfile(Guid userId);

        UserProfile CreateUserProfile(User user, UserProfile profile);

        UserProfile CreateUserProfile(Guid userId, UserProfile profile);

        void UpdateUserProfile(Guid userProfileId, UserProfile profile);

        UserProfile DeleteUserProfile(Guid userProfileId);
    }
}