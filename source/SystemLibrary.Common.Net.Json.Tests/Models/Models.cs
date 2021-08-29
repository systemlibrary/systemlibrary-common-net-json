using System;

namespace SystemLibrary.Common.Net.Json.Tests.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public int Age { get; set; }
    }

    public class Employee : User
    {
        public string Title;
        public int Salary { get; set; }
    }
}
