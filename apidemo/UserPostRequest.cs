using System;

namespace ApiDemo
{
    public class UserPostRequest
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
        public string BirthDate { get; set; } = DateTime.MaxValue.ToString();

        public bool Validate()
        {
            
            return true;
        }

        public override string ToString()
        {
            return "Name: " + Name + "; Pass: " + Password + "; Birthdate: " + BirthDate;
        }
    }
}