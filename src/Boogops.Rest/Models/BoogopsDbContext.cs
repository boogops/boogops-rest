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
        #region seed db data

        var things = new[]
        {
            new Thing
            {
                Id = "1"
            },
            new Thing
            {
                Id = "2"
            }
        };

        #endregion

        modelBuilder.Entity<Thing>().HasData(things);

        base.OnModelCreating(modelBuilder);
    }
}