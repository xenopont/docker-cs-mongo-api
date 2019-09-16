using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/whatever")]
    [ApiController]
    public class WhateverController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string Process(string param)
        {
            string result = "";
            foreach (char c in param)
            {
                int x = c;
                result += x.ToString();
            }
            return result;
        }
    }
}