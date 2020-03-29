using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Whitelabel.Service.APP.Validators;
using Whitelabel.Service.Domain.Entities;
using Whitelabel.Service.Domain.Interfaces.Repository;
using Whitelabel.Service.Domain.Interfaces.Services;

namespace Whitelabel.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> Usuarios([FromServices] IUserService userService, int id)
        {
            try
            {
                var user = userService.Get(id);
                return Ok(user);
            }
            catch(NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> NewUser([FromServices] IUserService userService, [FromBody] User user)
        {
            try
            {
                userService.Post<UserValidator>(user);

                return CreatedAtAction("NewUser", new { id = user.Id }, user);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

    }
}