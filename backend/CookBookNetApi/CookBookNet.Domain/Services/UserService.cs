using CookBookNet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookNet.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<List<User>> GetAll()
        {
            var result =  await this.userRepository.GetAll();
            return result.ToList();
        }

        public async Task<User> GetById(Guid id)
        {
            return await this.userRepository.GetSingle(id);
        }
    }
}
