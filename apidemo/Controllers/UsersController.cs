using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDemo.Models;
using ApiDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> UserList()
        {
            List<User> list = await Database.Db.UserList();
            return list;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> CreateUser(UserPostRequest request)
        {
            List<string> validationResult = request.Validate();
            if (validationResult.Count > 0)
            {
                return new BadRequestObjectResult(validationResult);
            }
            var user = new User
            {
                Name = request.Name,
                Password = request.Password,
                Age = (int)((DateTime.Now - DateTime.Parse(request.BirthDate)).TotalDays / 365.0),
            };
            if (!await Database.Db.Create(user))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
            user.Password = "*******";
            return Created("http://www.google.com/", user);
        }
    }
}
