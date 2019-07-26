using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ApiDemo.Models;
using ApiDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> UserList()
        {
            List<User> list = await Database.Db.UserList();
            return list;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateUser(UserPostRequest request)
        {
            List<string> validationResult = request.Validate();
            if (validationResult.Count > 0)
            {
                return new BadRequestObjectResult(validationResult);
                /*ObjectResult response = new ObjectResult(validationResult);
                response.StatusCode = 400;
                return response;*/
            }
            //Database.Db.Create(user);
            return new OkObjectResult(request.ToString());
        }
    }
}
