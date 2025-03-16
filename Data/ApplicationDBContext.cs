using EmployeeApi.Controllers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        //public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure correct mapping for MySQL
            //modelBuilder.Entity<Student>()
            //    .Property(s => s.FullName)
            //    .HasColumnType("TEXT");

            //modelBuilder.Entity<Student>()
            //    .Property(s => s.Class)
            //    .HasColumnType("TEXT");

            //modelBuilder.Entity<Student>()
            //    .Property(s => s.City)
            //    .HasColumnType("TEXT");

            //modelBuilder.Entity<Student>()
            //    .Property(s => s.State)
            //    .HasColumnType("TEXT");

            //Configure Employee Entity
            modelBuilder.Entity<Employee>()
                .ToTable("employees")
                .HasKey(e => e.EmpId);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpId)
                .HasColumnType("EmpId")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpName)
                .HasColumnName("EmpName")
                .HasColumnType("nvarchar(225)")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpDept)
                .HasColumnName("EmpDept")
                .HasColumnType("nvarchar(225)")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpPhone)
                .HasColumnName("EmpPhone")
                .HasColumnType("nvarchar(60)")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpSalary)
                .HasColumnName("EmpSalary")
                .HasColumnType("decimal(50,2)")
                .IsRequired();



            base.OnModelCreating(modelBuilder);
        }
    }
}
