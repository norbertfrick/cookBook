using Cookbook.Domain.DTO;
using Cookbook.Domain.Helpers;
using Cookbook.Domain.Interfaces;
using Cookbook.Domain.Interfaces.Repositories;
using Cookbook.Domain.Interfaces.Services;
using Cookbook.Domain.Model;
using Cookbook.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cookbook.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileService _userProfileService;
        private readonly IPasswordHashingService _passwordService;

        public LoginService(ITokenProvider tokenProvider, IUserRepository userRepository, IPasswordHashingService passwordService, IUserProfileService profileService)
        {
            this._tokenProvider = tokenProvider;
            this._userRepository = userRepository;
            this._passwordService = passwordService;
            this._userProfileService = profileService;
        }

        public async Task<RequestResponse<TokenWrapper>> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
                return new RequestResponse<TokenWrapper>(false, null, "User not found.");

            if (!_passwordService.ComparePassword(password + user.PasswordSalt, user.Password))
                return new RequestResponse<TokenWrapper>(false, null, "Password not correct.");
            try
            {
                var token = _tokenProvider.GenerateToken(new Dictionary<string, string> { { "email", user.Email } });
                var refreshToken = _tokenProvider.GenerateRefreshToken();

                await Task.WhenAll(token, refreshToken);

                user.RefreshToken = refreshToken.Result;

                await _userRepository.Update(user.Id, user);

                return new RequestResponse<TokenWrapper>(true, new TokenWrapper(token.Result, refreshToken.Result, user.Id));
            }
            catch (Exception ex)
            {
                return new RequestResponse<TokenWrapper>(false, null, ex.Message);
            }
            
        }

        public async Task<RequestResponse<string>> Logout(Guid id)
        {
            try
            {
                var user = await _userRepository.GetById(id);

                user.RefreshToken = string.Empty;

                await _userRepository.Update(id, user);

                return new RequestResponse<string>(true, null);

            }
            catch (Exception ex)
            {
                return new RequestResponse<string>(false, null, ex.Message);
            }

        }
    }
}
