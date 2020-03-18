using Microsoft.EntityFrameworkCore;
using SchoolDbLections.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDbLections
{
    class Program
    {
        static void Main(string[] args)
        {
            //SchoolDbContext schoolDbContext = new SchoolDbContext();
            //Student student = schoolDbContext.Students.Find(2);
            //Console.WriteLine(student.Name);
            //Console.WriteLine("----------------------");

            //Student st = schoolDbContext.Students.Where(s => s.Name == "Vlad").FirstOrDefault();
            //Console.WriteLine(st.Name);
            //Console.WriteLine("----------------------");

            //var pups = schoolDbContext.Students.OrderByDescending(p => p.Name);
            //foreach (var pup in pups)
            //{
            //    Console.WriteLine(pup.Name);
            //}
            //Console.WriteLine("----------------------");

            //var pupsGroup = schoolDbContext.Students.Where(p => p.Name == "Vlad")
            //    .Include(i => i.Grade)
            //    .FirstOrDefault();

            //Console.WriteLine("----------------------");

            //Student vlad = schoolDbContext.Students.FirstOrDefault(v => v.Name == "Vlad");
            //schoolDbContext.Entry(vlad).Reference(s => s.Grade).Load();
            //schoolDbContext.Entry(vlad).Collection(s => s.StudentCourses).Load();
            //Console.WriteLine("----------------------");

            //// lazy loading
            //using (var ctx = new SchoolDbContext())
            //{
            //    List<Student> stList = ctx.Students.ToList();
            //}




            //var student = new Student()
            //{
            //    Id = 1,
            //    Name = "Bill",
            //    Address = new StudentAddress()
            //    {
            //        StudentAddressId = 1,
            //        City = "Seatle",
            //        Country = "USA"
            //    },
            //    StudentCourses = new List<StudentCourse>()
            //    {
            //        new StudentCourse(){ Course = new Course(){ CourseName = "Machi"} },
            //        new StudentCourse(){ Course = new Course(){ CourseId = 2} }
            //    }
            //};

            //var context = new SchoolDbContext();
            //context.Students.Add(student);
            //context.SaveChanges();//error accured checked on purpose



            var name = "Vlad";
            var context = new SchoolDbContext();
            var students = context.Students
                .FromSqlRaw($"GetStudents {name}")
                .ToList();

            var stud = context.Database.ExecuteSqlRaw("update Students set Name = 'Ladya' where Id = 3");



            Console.ReadKey();
        }
    }
}
