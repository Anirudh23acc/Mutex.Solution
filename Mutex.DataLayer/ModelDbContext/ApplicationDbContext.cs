using Microsoft.EntityFrameworkCore;
using Mutex.DataLayer.Models;
namespace Mutex.DataLayer.ModelDbContext;

public class ApplicationDbContext:DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
    {

    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=AT1IND235806861;Database=MutexDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(e => e.EmpSalary)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Admin>()
            .HasData(new Admin { AdminId = 1, UserName="admin",Password="admin123"});
    }
}
