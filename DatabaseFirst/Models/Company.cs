namespace DatabaseFirst.Models;

public partial class Company
{
    public Guid Id { get; set; }

    public virtual ICollection<Office> Offices { get; set; } = new List<Office>();

    public virtual ICollection<Person> Employees { get; set; } = new List<Person>();
}
