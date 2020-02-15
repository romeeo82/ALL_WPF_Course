using HRdatabaseFluentApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabaseFluentApi.Models
{
    class HrDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=DESKTOP-ELNAA5R\SQLEXPRESS;DataBase=HRfluentApi;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany(d => d.Employees);

            modelBuilder.Entity<Employee>()
             .HasOne<JobHistory>(e => e.JobHistory)
             .WithMany(j => j.Employees);

            modelBuilder.Entity<Employee>()
             .HasOne<Job>(e => e.Job)
             .WithMany(j => j.Employees);

            modelBuilder.Entity<JobHistory>()
             .HasOne<Department>(j => j.Department)
             .WithMany(d => d.JobHistories);

            modelBuilder.Entity<JobHistory>()
             .HasOne<Job>(j => j.Job)
             .WithMany(j => j.JobHistories);
            modelBuilder.Entity<JobHistory>().HasKey(sc => new { sc.EmployeeId, sc.HiredDate });

            modelBuilder.Entity<Department>()
             .HasOne<Location>(d => d.Location)
             .WithMany(l => l.Departments);

            modelBuilder.Entity<Country>()
             .HasOne<Region>(c => c.Region)
             .WithMany(r => r.Countries);

            modelBuilder.Entity<Location>()
             .HasOne<Country>(l => l.Country)
             .WithMany(c => c.Locations);
        }
    }
}
