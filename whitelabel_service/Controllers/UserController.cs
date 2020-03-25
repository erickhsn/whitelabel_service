using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Whitelabel.Service.Domain.Entities;
using Whitelabel.Service.Domain.Interfaces.Repository;

namespace Whitelabel.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> Usuarios([FromServices] IUserRepository userRepository, int id)
        {
            return Ok(userRepository.Get(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> NewUser([FromServices] IUserRepository userRepository, [FromBody] User user)
        {
            userRepository.Insert(user);

            return CreatedAtAction("NewUser", new { id = user.Id }, user);

        }

    }
}