using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDemo.Models;
using ApiDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const string HiddenPassword = "********";
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<User>>> UserList()
        {
            List<User> list = null;
            try
            {
                list = await Database.Db.UserList();
            }
            catch (MongoException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            foreach (var user in list)
            {
                user.Password = HiddenPassword;
            }

            return list;
        }

        [HttpGet("{userId}")] // the format {userId:length(24)} returns 404 Not Found in case the user ID is invalid instead of meaningful 400 Bad Request
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetUserDetails(string userId)
        {
            if (!ObjectId.TryParse(userId, out ObjectId objectId))
            {
                return new BadRequestObjectResult(new List<string> { "Invalid user ID" });
            }
            
            User user = null;
            try
            {
                user = await Database.Db.UserDetails(userId);
            }
            catch (MongoException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (user == null)
            {
                return NotFound(null);
            }

            user.Password = HiddenPassword;

            return user;
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
                Age = Converter.BirthdateToAge(request.BirthDate),
            };

            try
            {
                await Database.Db.Create(user);
            }
            catch (MongoWriteException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            user.Password = HiddenPassword;
            return Created("/api/users/" + user.Id, user);
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> UpdateUser(string userId, UserPutRequest request)
        {
            request.Id = userId;
            if (!request.IsValid(out List<string> errors))
            {
                return new BadRequestObjectResult(errors);
            }

            int? age = null;
            if (request.BirthDate != null)
            {
                age = Converter.BirthdateToAge(request.BirthDate);
            }

            try
            {
                await Database.Db.Update(request.Id, request.Password, age);
            }
            catch (MongoException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
