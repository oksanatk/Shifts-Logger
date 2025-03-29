using Microsoft.EntityFrameworkCore;
using ShiftsLogger.WebApi.Models;

namespace ShiftsLogger.WebApi.Data;

public class WorkerShiftContext : DbContext
{
    internal DbSet<Worker> Workers { get; set; } = null!;
    internal DbSet<Shift> Shifts { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("LocalWorkerShiftDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shift>()
            .HasOne(s => s.Worker)
            .WithMany(s => s.Shifts)
            .HasForeignKey(s => s.WorkerId)
            .IsRequired();
    }
}
