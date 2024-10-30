using Microsoft.EntityFrameworkCore;
using PlaymoveTechTest.Domain.Model;

namespace PlaymoveTechTest.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options, bool applyMigration = default) : base(options)
    {
        if (Database.IsRelational() && applyMigration)
            Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Supplier> Suppliers { get; set; }
}