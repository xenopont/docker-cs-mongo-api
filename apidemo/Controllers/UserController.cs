﻿using System.Collections.Generic;
using System.Threading.Tasks;
using apidemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace apidemo.Controllers
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
        public ActionResult<string> CreateUser([FromBody] User user)
        {
            Database.Db.Create(user);
            return "OK";
        }
    }
}