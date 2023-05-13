using DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

using (OfficeContext dbContext = new())
{
    IQueryable<Person> people = dbContext.People
        .Include(x => x.Address)
        .Include(x => x.Companies)
        .ThenInclude(x => x.Offices)
        .ThenInclude(x => x.Address);

    await dbContext.People
            .Select(x => x.Name)
            .ForEachAsync(Console.WriteLine);

    await dbContext.Offices
            .Select(x => x.Address.Country)
            .ForEachAsync(Console.WriteLine);
}
