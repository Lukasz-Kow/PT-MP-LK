﻿
using Services.API;

namespace Presentations.Model
{
    public class CustomerModel
    {

        public CustomerModel(string firstName, string lastName, string id, int age, string address, string city) 
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Age = age;
            Address = address;
            City = city;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
       

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Id}";
        }
    }
}
