﻿using Cookbook.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        public Task<User> GetByEmail(string email); 
    }
}
