﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces.Services
{
    public interface ITokenProvider
    {
        public string GenerateToken(Dictionary<string, string> claims);

        public Task<string> GenerateToken(string refreshToken, Dictionary<string, string> claims);

        public string GenerateRefreshToken(Guid userId);

        public Task<Guid> GetUserIdByRefreshToken(string refreshToken);

    }
}
