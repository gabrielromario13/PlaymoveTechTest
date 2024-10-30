using Microsoft.EntityFrameworkCore;
using PlaymoveTechTest.Domain.Model;

namespace PlaymoveTechTest.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Supplier> Suppliers { get; set; }
}