using CompensationRetirementEstimator.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CompensationRetirementEstimator.Api.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<RetirementProjection> RetirementProjections => Set<RetirementProjection>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<RetirementProjection>().HasOne(rp => rp.User)
        .WithMany() // later you can add .WithMany(u => u.RetirementProjections)
        .HasForeignKey(rp => rp.UserId);
    }
}

