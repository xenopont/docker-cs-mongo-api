using System;
using System.Collections.Generic;

namespace ApiDemo.Models
{
    public class UserPostRequest
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
        public string BirthDate { get; set; } = DateTime.MaxValue.ToString();

        public List<string> Validate()
        {
            List<string> errorMessages = new List<string>();
            errorMessages.Add("I don't like the request");
            
            return errorMessages;
        }

        public override string ToString()
        {
            return "Name: " + Name + "; Pass: " + Password + "; Birthdate: " + BirthDate;
        }
    }
}