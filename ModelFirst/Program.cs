using ModelFirst.Context;
using ModelFirst.Model;
using Microsoft.EntityFrameworkCore;

using (ExampleDbContext exampleDbContext = new())
{
    exampleDbContext.Database.EnsureCreated();

    // Create a new address
    Address addressCompany1 = new()
    {
        Street = "Street",
        City = "City",
        ZipCode = "477 12",
        Country = "Chechnya",
        Number = "32/a"
    };

    Address addressCompany2 = new()
    {
        Street = "Street",
        City = "Paříž",
        ZipCode = "477 12",
        Country = "Czechia",
        Number = "891"
    };

    Address addressEmployee = new()
    {
        Street = "Street",
        City = "City",
        ZipCode = "477 12",
        Country = "Chechnya",
        Number = "32/b"
    };

    Office officeCzechia = new()
    {
        Address = addressCompany2
    };

    // Create a new company
    Company company = new()
    {
        Employees = new List<Person>()
        { 
            new() 
            { 
                Name = "Tomáš", 
                Surname = "Pech", 
                BirthNumber = 1234561234,
                Email = "tomas@pe.ch",
                Address = addressEmployee,
                Companies = new List<Company>()
                {
                    new Company
                    {
                        Offices = new List<Office>()
                        {
                            officeCzechia
                        }
                    }
                }
            }
        }
    };

    // Create a new office
    Office officeChechnya = new()
    {
        Company = company,
        Address = addressCompany1
    };

    // Add the office to the database
    exampleDbContext.Offices.Add(officeChechnya);

    // Commit
    exampleDbContext.SaveChanges();

    IQueryable<Person> people = exampleDbContext.People
        .Include(x => x.Address)
        .Include(x => x.Companies)
        .ThenInclude(x => x.Offices)
        .ThenInclude(x => x.Address);

    await exampleDbContext.People
            .Select(x => x.Name)
            .ForEachAsync(Console.WriteLine);

    await exampleDbContext.Offices
            .Select(x => x.Address.Country)
            .ForEachAsync(Console.WriteLine);
}