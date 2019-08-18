using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace ApiDemo.Models
{
    public class UserPutRequest
    {
        public string Id { get; set; } = null;
        public string BirthDate { get; set; } = null;
        public string Password { get; set; } = null;

        public bool IsValid(out List<string> errors)
        {
            errors = new List<string>();
            
            if (BirthDate == null && Password == null)
            {
                errors.Add("No data to update");
                return false;
            }

            if (Id == null || !ObjectId.TryParse(Id, out var o))
            {
                errors.Add("User ID is of invalid format");
                return false;
            }

            if (BirthDate != null && !DateTime.TryParse(BirthDate, out DateTime d))
            {
                errors.Add("Birth Date is of invalid format");
            }

            if (Password == "")
            {
                errors.Add("Password can not be empty");
            }

            return errors.Count == 0;
        }
    }
}