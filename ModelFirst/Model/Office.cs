namespace ModelFirst.Model
{
    public class Office
    {
        public Guid Id { get; set; }
        public Company Company { get; set; }
        public Address Address { get; set; }
    }
}
