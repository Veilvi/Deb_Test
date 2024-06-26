using Deb_test.Models;
using Microsoft.EntityFrameworkCore;

namespace Deb_test.Data;

public class DebDbContext : DbContext
{
    public DbSet<Employee>   Employees  { get; set; }
    public DbSet<JobTitle>   JobTitles  { get; set; }
    public DbSet<WorkShift>  WorkShifts { get; set; }
    
    public DebDbContext(DbContextOptions<DebDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobTitle>().HasData(
            new JobTitle { Id = 1, Name = "Менеджер" },
            new JobTitle { Id = 2, Name = "Инженер" },
            new JobTitle { Id = 3, Name = "Тестировщик свечей" }
        );
    }
}