using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/whatever")]
    [ApiController]
    public class WhateverController : ControllerBase
    {
        [HttpGet("{param}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string Process(string param)
        {
            string result = "";
            Random random = new Random();
            foreach (char c in param)
            {
                int x = (int) c;
                x *= random.Next(0, 1000);
                while (x > 127)
                {
                    x /= 2;
                }
                result += x.ToString();
            }
            return result;
        }
    }
}