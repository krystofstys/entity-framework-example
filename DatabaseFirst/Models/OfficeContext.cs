using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Models;

public partial class OfficeContext : DbContext
{
    public OfficeContext()
    {
    }

    public OfficeContext(DbContextOptions<OfficeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Office;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(d => d.Employees).WithMany(p => p.Companies)
                .UsingEntity<Dictionary<string, object>>(
                    "CompanyPerson",
                    r => r.HasOne<Person>().WithMany().HasForeignKey("EmployeesId"),
                    l => l.HasOne<Company>().WithMany().HasForeignKey("CompaniesId"),
                    j =>
                    {
                        j.HasKey("CompaniesId", "EmployeesId");
                        j.ToTable("CompanyPerson");
                        j.HasIndex(new[] { "EmployeesId" }, "IX_CompanyPerson_EmployeesId");
                    });
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasIndex(e => e.AddressId, "IX_Offices_AddressId");

            entity.HasIndex(e => e.CompanyId, "IX_Offices_CompanyId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Address).WithMany(p => p.Offices).HasForeignKey(d => d.AddressId);

            entity.HasOne(d => d.Company).WithMany(p => p.Offices).HasForeignKey(d => d.CompanyId);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasIndex(e => e.AddressId, "IX_People_AddressId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Address).WithMany(p => p.People).HasForeignKey(d => d.AddressId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
