using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                          .EnableSensitiveDataLogging()
                          .UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Company;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().OwnsMany(e => e.Payments);

            modelBuilder.Entity<Responsibility>(r =>
            {
                r.HasKey(r => new { r.EmployeeID, r.TaskID });
                r.HasOne(r => r.Employee).WithMany(e => e.Tasks);
            });

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, Name = "Mark", Lastname = "Louis", Birthday = new DateTime(1987, 6, 2), DepartmentID = 1 },
                new Employee { EmployeeID = 2, Name = "Luna", Lastname = "Jones", Birthday = new DateTime(1989, 1, 12), DepartmentID = 2 }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID=1, Name = "Marketing" },
                new Department { DepartmentID=2, Name = "IT" }
            );
            modelBuilder.Entity<Task>().HasData(
                new Task { TaskID = 1, Name = "Marketing strategy" },
                new Task { TaskID = 2, Name = "App deployment" }
            );
        }
    }
}
