using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Respaldo.Models;
using Respaldo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Respaldo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        new UsersService userS = new UsersService();

        [HttpPost]
        public IActionResult PostUser([FromBody] User newUser)
        {

            userS.AddUser(newUser);
            return Ok();

        }
    }
}
