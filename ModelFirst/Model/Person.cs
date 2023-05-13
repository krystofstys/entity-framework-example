using System.ComponentModel.DataAnnotations;

namespace ModelFirst.Model
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MinLength(1)]
        [StringLength(50)]
        public string Surname { get; set; }
        public string Email { get; set; }
        public int BirthNumber { get; set; }
        public Address Address { get; set; }
        public virtual List<Company> Companies { get; set; }
    }
}
