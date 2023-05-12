namespace DatabaseFirst.Models;

public partial class Address
{
    public Guid Id { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public string? Country { get; set; }

    public string? Number { get; set; }

    public virtual ICollection<Office> Offices { get; set; } = new List<Office>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
