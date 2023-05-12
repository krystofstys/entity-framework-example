using ModelFirst.Context;
using ModelFirst.Model;
using Microsoft.EntityFrameworkCore;

using (ExampleDbContext exampleDbContext = new())
{
    exampleDbContext.Database.MigrateAsync();

    // Create a new address
    Address address = new()
    {
        Street = "Street",
        City = "City",
        ZipCode = "ZipCode",
        Country = "Country",
        Number = "Number"
    };

    // Create a new company
    Company company = new()
    {
        Employees = new List<Person>()
    };

    // Create a new office
    Office office = new()
    {
        Company = company,
        Address = address
    };

    // Add the office to the database
    exampleDbContext.Offices.Add(office);

    // Commit
    exampleDbContext.SaveChanges();

    Console.WriteLine(exampleDbContext.People.Include(x => x.Address).Include(x => x.Companies).ToList());
}