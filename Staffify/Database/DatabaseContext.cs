using Microsoft.EntityFrameworkCore;
using Staffify.Models.Data;
namespace Staffify.Database;

public class DatabaseContext : DbContext
{
    // Build DB - Options
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Set DB name
        optionsBuilder.UseInMemoryDatabase(databaseName: "StaffifyDB");
    }

    // Tables
    public DbSet<Employee>? Employees { get; set; }
}
