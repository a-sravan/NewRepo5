using EmployeeApi.Controllers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure correct mapping for MySQL
            modelBuilder.Entity<Student>()
                .Property(s => s.FullName)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Student>()
                .Property(s => s.Class)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Student>()
                .Property(s => s.City)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Student>()
                .Property(s => s.State)
                .HasColumnType("TEXT");

            base.OnModelCreating(modelBuilder);
        }
    }
}
