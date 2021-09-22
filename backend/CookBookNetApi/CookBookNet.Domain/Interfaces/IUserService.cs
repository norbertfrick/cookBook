using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetById(Guid id);

        public Task<List<User>> GetAll();
    }
}
