using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Api.Controllers
{
    [ApiController]
    [Route("api/user/profile")]
    public class UserProfileController : ControllerBase
    {
        [HttpPatch]
        [Authorize]
        public ActionResult<UserProfile> Update([FromBody] UserProfile profile)
        {
            return Ok();
        }
    }
}