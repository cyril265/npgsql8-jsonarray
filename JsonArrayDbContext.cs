using Microsoft.EntityFrameworkCore;


public class Person
{
    public int Id { get; init; }
    public required List<Address> Addresses { get; init; }
}

public class Address
{
    public required string City { get; init; }
    public required string Zip { get; init; }
    public required string Street { get; init; }
}

public class FooDbContext : DbContext
{
    public FooDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Person>()
            .Property(p => p.Addresses)
            .HasColumnType("jsonb[]");
    }
    
    public DbSet<Person> Person { get; init; } = null!;
}