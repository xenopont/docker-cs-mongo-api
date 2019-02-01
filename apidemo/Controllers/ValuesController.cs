using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;

namespace apidemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        protected Database _db = null;
        protected Database Db {
            get {
                if (_db == null) {
                    _db = new Database();
                }
                return _db;
            }
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<BsonDocument>> Get()
        {
            List<BsonDocument> list = await Db.LoadDocumentsAsync();
            return new BsonDocument(new Dictionary<string, object>() {
                { "ListCount", list.Count }
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
