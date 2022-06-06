using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MIS.Backend.Common.Interfaces;
using MIS.Backend.Models;

namespace MIS.Backend.DataAccess;

public class DatabaseContext : DbContext
{
    private readonly IConfigurationHelper _configurationHelper;

    public DbSet<ConfigurationValue> ConfigurationValues { get; set; }

    public DatabaseContext(IConfigurationHelper configurationHelper)
    {
        _configurationHelper = configurationHelper;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configurationHelper.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConfigurationValue>(e =>
        {
            e.ToTable("CONFIGURATION").HasKey(x => x.Id);
            e.Property(p => p.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
            e.Property(p => p.Value).IsRequired();
        });
    }
}