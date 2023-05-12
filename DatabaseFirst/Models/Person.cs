namespace DatabaseFirst.Models;

public partial class Person
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public int BirthNumber { get; set; }

    public Guid? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
