using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDemo.Models;
using ApiDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> UserList()
        {
            List<User> list = await Database.Db.UserList();
            return list;
        }

        [HttpPost]
        public ActionResult<string> CreateUser(UserPostRequest request)
        {
            
            //Database.Db.Create(user);
            return request.ToString();
        }
    }
}
