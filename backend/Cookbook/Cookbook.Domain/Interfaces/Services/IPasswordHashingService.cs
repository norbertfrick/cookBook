using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Interfaces.Services
{
    public interface IPasswordHashingService
    {
        public (string password, string salt) HashPassword();

        public bool ComparePassword(string password1, string password2);
    }
}
