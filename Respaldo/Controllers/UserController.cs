using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Respaldo.Models;
using Respaldo.Services;
using Respaldo.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Respaldo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        new UsersService userS = new UsersService();


        [HttpGet]
        public List<User> GetUsers()
        {
            var users = userS.GetAllUsers().Select(s => new User
            {
                ProductId = s.ProductId,
                Username = s.Username,
                Email = s.Email
            }).ToList();
            return users;
        }



        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {

            //var user = UserRepository.Get(model.Username, model.Password);
            var user = userS.Login(model.Username, model.UserPass);
            if (user == null)
                return NotFound(new { message = "User or password invalid" });

            var token = TokenService.CreateToken(user);
            user.UserPass = "";
            return new
            {
                user = user,
                token = token
            };

            
        }
    }
}
