using CompensationRetirementEstimator.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CompensationRetirementEstimator.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<RetirementProjection> RetirementProjections => Set<RetirementProjection>();
}

