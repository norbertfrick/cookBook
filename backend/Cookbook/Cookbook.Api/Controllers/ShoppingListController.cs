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
    [Authorize]
    [Route("api/user/shoppinglist")]
    public class ShoppingListController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ShoppingList> Get([FromQuery] Guid userId)
        {
            return Ok();
        }

        [HttpPatch]
        public ActionResult<ShoppingList> Update()
        {
            return Ok();
        }
    }
}