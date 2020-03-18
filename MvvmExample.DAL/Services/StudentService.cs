using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MvvmExample.DAL.Model;

namespace MvvmExample.DAL.Services
{
    public class StudentService : IStudentService
    {
        private StudentDbContext _context;
        public StudentService()
        {
            this._context = new StudentDbContext();
        }

        public IEnumerable<Student> GetStudents()
        {
            return this._context.Students.Include(s => s.Address).Include(s => s.Books);
        }

        public void SaveStudents()
        {
            this._context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            this._context.Students.Remove(student);
        }

        public void DeleteBook(int studentId,Book book)
        {
            this._context.Students.Find(studentId).Books.Remove(book);
            //this._context.Books.Remove(book);
        }
    }
}