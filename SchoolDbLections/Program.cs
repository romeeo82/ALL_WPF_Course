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
            SchoolDbContext schoolDbContext = new SchoolDbContext();
            Student student = schoolDbContext.Students.Find(2);
            Console.WriteLine(student.Name);
            Console.WriteLine("----------------------");

            Student st = schoolDbContext.Students.Where(s => s.Name == "Vlad").FirstOrDefault();
            Console.WriteLine(st.Name);
            Console.WriteLine("----------------------");

            var pups = schoolDbContext.Students.OrderByDescending(p => p.Name);
            foreach (var pup in pups)
            {
                Console.WriteLine(pup.Name);
            }
            Console.WriteLine("----------------------");

            var pupsGroup = schoolDbContext.Students.Where(p => p.Name == "Vlad")
                .Include(i => i.Grade)
                .FirstOrDefault();

            Console.WriteLine("----------------------");

            Student vlad = schoolDbContext.Students.FirstOrDefault(v=>v.Name == "Vlad");
            schoolDbContext.Entry(vlad).Reference(s => s.Grade).Load();
            schoolDbContext.Entry(vlad).Collection(s => s.StudentCourses).Load();
            Console.WriteLine("----------------------");

            // lazy loading
            using (var ctx = new SchoolDbContext())
            {
                List<Student> stList = ctx.Students.ToList();
            }

            Console.ReadKey();
        }
    }
}
