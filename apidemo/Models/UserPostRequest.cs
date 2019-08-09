using System;
using System.Collections.Generic;

namespace ApiDemo.Models
{
    public class UserPostRequest
    {
        private const string StringNoDataProvided = "no data provided";

        public string Name { get; set; } = StringNoDataProvided;
        public string Password { get; set; } = StringNoDataProvided;
        public string BirthDate { get; set; } = StringNoDataProvided;

        public List<string> Validate()
        {
            var errorMessages = new List<string>();
            if (Name == StringNoDataProvided)
            {
                errorMessages.Add("User Name is not provided");
            }
            if (Password == StringNoDataProvided)
            {
                errorMessages.Add("Password is not provided");
            }
            if (BirthDate == StringNoDataProvided)
            {
                errorMessages.Add("Birth Date is not provided");
            }
            if (!DateTime.TryParse(BirthDate, out var d))
            {
                errorMessages.Add("Birth Date is of invalid format");
            }
            
            return errorMessages;
        }
    }
}