using System;

namespace ApiDemo
{
    public class UserPostRequest
    {
        private string _name = "";
        private string _password = "";
        private DateTime _birthDate = DateTime.MaxValue;
        
        public string name
        {
            get => _name;
            set => _name = value;
        }

        public string password
        {
            get => _password;
            set => _password = value;
        }

        public bool Validate()
        {
            
            return true;
        }

        public override string ToString()
        {
            return "Name: " + _name + "; Pass: " + _password + "; Birthdate: " + _birthDate;
        }
    }
}