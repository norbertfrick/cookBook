using CookBookNet.Domain;
using CookBookNet.Domain.Interfaces;
using CookBookNetApi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookNetApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IEntityMapper<UserDto, User> mapper;

        public UserController(IUserService userService, IEntityMapper<UserDto, User> mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = new List<UserDto>();

            try
            {
                var users = await this.userService.GetAll();
                result = users.Select(r => mapper.MapToDto(r)).ToList();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            UserDto result;

            try
            {
                var user = await this.userService.GetById(id);
                result = mapper.MapToDto(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

            return Ok(result);

        }
    }
}
