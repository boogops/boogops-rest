using Microsoft.EntityFrameworkCore;

namespace Boogops.Rest.Models;

public class BoogopsDbContext : DbContext
{
    public BoogopsDbContext(DbContextOptions<BoogopsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Thing> Things { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}