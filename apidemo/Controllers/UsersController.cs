using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using apidemo.Models;

namespace apidemo.Controllers
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
        public ActionResult<string> CreateUser([FromBody] User user)
        {
            Database.Db.Create(user);
            return "OK";
        }
    }
}
