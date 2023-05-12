namespace ModelFirst.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int BirthNumber { get; set; }
        public Address Address { get; set; }
        public virtual List<Company> Companies { get; set; }
    }
}
