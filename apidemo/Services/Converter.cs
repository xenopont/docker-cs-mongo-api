using System;

namespace ApiDemo.Services
{
    public class Converter
    {
        public static int BirthdateToAge(string date)
        {
            return (int) ((DateTime.Now - DateTime.Parse(date)).TotalDays / 365.0);
        }
    }
}