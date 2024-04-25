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
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LoginService(ITokenProvider tokenProvider, IUserRepository userRepository, IPasswordHashingService passwordService, /*IUserProfileService profileService,*/ IRefreshTokenRepository refreshTokenRepository)
        {
            this._tokenProvider = tokenProvider;
            this._userRepository = userRepository;
            this._passwordService = passwordService;
            //this._userProfileService = profileService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RequestResponse<TokenWrapper>> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
                return new RequestResponse<TokenWrapper>(false, null, "User not found.");

            if (!_passwordService.IsPasswordValid(password, user.Password, user.PasswordSalt))
                return new RequestResponse<TokenWrapper>(false, null, "Password not correct.");
            try
            {
                var token = _tokenProvider.GenerateToken(CreateClaims(user));
                var refreshToken = _tokenProvider.GenerateRefreshToken(user.Id);

                return new RequestResponse<TokenWrapper>(true, new TokenWrapper(token, refreshToken, user.Id));
            }
            catch (Exception ex)
            {
                return new RequestResponse<TokenWrapper>(false, null, ex.Message);
            }
            
        }

        public async Task<RequestResponse<string>> Logout(Guid id, string tokenValue)
        {
            try
            {
                var refreshToken = await _refreshTokenRepository.GetByTokenValue(tokenValue);
                refreshToken.IsExpired = true;

                _refreshTokenRepository.Update(refreshToken.Id, refreshToken);

                return new RequestResponse<string>(true, null);

            }
            catch (Exception ex)
            {
                return new RequestResponse<string>(false, null, ex.Message);
            }

        }

        public async Task<RequestResponse<TokenWrapper>> RefreshToken(string refreshToken)
        {
            //should be able to get email from token claims and get the user that way
            //this is a temporary solution
            var userId = await _tokenProvider.GetUserIdByRefreshToken(refreshToken);
            var user = await _userRepository.GetById(userId);

            var newToken = _tokenProvider.GenerateToken(CreateClaims(user));

            var tokenWrapper = newToken.Equals(string.Empty) ? null : new TokenWrapper(newToken, refreshToken, userId);

            return new RequestResponse<TokenWrapper>(!(tokenWrapper is null), tokenWrapper, tokenWrapper is null ? "Failed to generate new token" : string.Empty);

        }

        public async Task<RequestResponse<Nullable<Guid>>> RegisterUser(string username, string password)
        {
            var existingUser = await _userRepository.GetByEmail(username);

            if (existingUser is not null)
                return new RequestResponse<Nullable<Guid>>(false, null, "User with that email already exists.");

            var passwordHash = _passwordService.HashPassword(password);

            var user = new User();
            user.Email = username;
            user.Password = passwordHash.password;
            user.PasswordSalt = passwordHash.salt;
            try
            {
                var createdUser = _userRepository.Create(user);

                return new RequestResponse<Nullable<Guid>>(true, createdUser.Id);
            }
            catch (Exception ex)
            {
                return new RequestResponse<Nullable<Guid>>(false, null, ex.Message);
            }
        }

        private Dictionary<string, string> CreateClaims(User user)
        {
            return new Dictionary<string, string> { { "email", user.Email } };
        }
    }
}
