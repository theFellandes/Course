using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            string customerName = customer.FirstName;
            string customerCity = customer.City;

            Person[] persons = new Person[3]
            {
                new Customer
                {
                    FirstName = "Engin"
                },
                new Student
                {
                    FirstName = "Derin"
                },
                new Person
                {
                    FirstName = "Salih"
                }
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Customer : Person
    {
        public string City { get; set; }
    }

    class Student : Person
    {
        public int StudentId { get; set; }
    }
}