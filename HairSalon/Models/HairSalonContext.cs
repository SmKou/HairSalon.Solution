namespace HairSalon.Models;

public class HairSalonContext : DbContext
{
    public DbSet<> { get; set; }

    public HairSalonContext(DbContextOptions options) : base(options)
    {}
}