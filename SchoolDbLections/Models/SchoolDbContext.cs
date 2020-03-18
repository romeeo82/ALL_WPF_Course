using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDbLections.Models
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
        //    new ConsoleLoggerProvider((_, __) => true, true)
        //});
        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory().AddConsole((_,___)=>true);


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                                 //.UseLoggerFactory(loggerFactory)
                                 //.EnableSensitiveDataLogging()
                                   .UseSqlServer(@"Server=DESKTOP-ELNAA5R\SQLEXPRESS;DataBase=SchoolDbLections;Trusted_Connection=True;")
                                   .UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGradeId);

            modelBuilder.Entity<Student>()
                .HasOne<StudentAddress>(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<StudentAddress>(s => s.AddressOfStudentId);

            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });


            //shadow property addition
            var allEntities = modelBuilder.Model.GetEntityTypes();
            foreach (var entity in allEntities)
            {
                entity.AddProperty("CreateDate", typeof(DateTime?));
                entity.AddProperty("UpdateDate", typeof(DateTime?));
            }
        }
    }
}
