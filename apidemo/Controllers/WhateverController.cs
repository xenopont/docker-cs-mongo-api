using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/whatever")]
    [ApiController]
    public class WhateverController : ControllerBase
    {
        private string splitAndSum(string param)
        {
            if (param.Length < int.MaxValue.ToString().Length)
            {
                return param;
            }

            int pos = param.Length / 2;
            string part1 = splitAndSum(param.Substring(0, pos));
            string part2 = splitAndSum(param.Substring(pos));
            
            if (int.Parse(part1) >= int.MaxValue / 2)
            {
                part1 = (int.Parse(part1) / 2).ToString();
            }
            if (int.Parse(part2) >= int.MaxValue / 2)
            {
                part2 = (int.Parse(part2) / 2).ToString();
            }
            
            return (int.Parse(part1) + int.Parse(part2)).ToString();
        }
        
        [HttpGet("{param}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string Process(string param)
        {
            string result = "";
            Random random = new Random();
            
            foreach (char c in param)
            {
                int x = (int) c;
                x *= random.Next(1, 1000);
                while (x > 127)
                {
                    x /= 2;
                }
                if (x < 32)
                {
                    x = random.Next(32, 127);
                }
                result += x.ToString();
            }

            result = int.Parse(splitAndSum(result)).ToString("X").ToLower();
            return result;
        }
    }
}
