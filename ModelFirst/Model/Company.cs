namespace ModelFirst.Model
{
    public class Company
    {
        public Guid Id { get; set; }
        public virtual List<Office> Offices { get; set; }
        public virtual List<Person> Employees { get; set; }
    }
}
