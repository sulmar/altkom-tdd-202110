using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus.Extensions.Poland;

namespace Api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal Salary { get; set; }
        public string Pesel { get; set; }
        public bool IsRemoved { get; set; }
    }

    public enum Gender
    {
        Male,
        Female       
    }

    public interface ICustomerRepository
    {
        List<Customer> Get();
        void Remove(int id);
    }




    // Install-Package Bogus

    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            StrictMode(true);
            UseSeed(0);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Gender, f => (Gender) f.Person.Gender);
            RuleFor(p => p.BirthDay, f => f.Person.DateOfBirth);
            RuleFor(p => p.Salary, f => f.Random.Decimal(1, 1000));
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));

            // Install-Package Sulmar.Bogus.Extensions.Poland
            // Ignore(p => p.Pesel);

            RuleFor(p => p.Pesel, f => f.Person.Pesel());   // add using Bogus.Extensions.Poland;
        }
    }

    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers;

        public FakeCustomerRepository()
        {
            CustomerFaker faker = new CustomerFaker();

            customers = faker.Generate(100);
        }

        public List<Customer> Get()
        {
            return customers;
        }

        public void Remove(int id)
        {

        }


    }
}
