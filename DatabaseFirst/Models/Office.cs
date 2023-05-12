namespace DatabaseFirst.Models;

public partial class Office
{
    public Guid Id { get; set; }

    public Guid? CompanyId { get; set; }

    public Guid? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Company? Company { get; set; }
}
