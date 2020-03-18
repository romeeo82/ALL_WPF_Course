using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using University.DAL.Models;

namespace University.DAL
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=DESKTOP-ELNAA5R\SQLEXPRESS;DataBase=University;Trusted_Connection=True;")
                                   .UseLazyLoadingProxies();

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //        .HasOne<Grade>(s => s.Grade)
        //        .WithMany(g => g.Students)
        //        .HasForeignKey(s => s.CurrentGradeId);

        //    modelBuilder.Entity<Student>()
        //        .HasOne<StudentAddress>(s => s.Address)
        //        .WithOne(a => a.Student)
        //        .HasForeignKey<StudentAddress>(s => s.AddressOfStudentId);

        //    modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
        //}
    }
}
