using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace apidemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
    {
        [HttpGet]
        public async Task<ActionResult<List<BsonDocument>>> UserList()
        {
            List<BsonDocument> list = await Database.Db.LoadDocumentsAsync();
            return list;
        }
    }
}
