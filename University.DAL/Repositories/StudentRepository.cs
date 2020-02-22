using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using University.DAL.Models;


namespace University.DAL.Repositories
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private UniversityDbContext context;

        private bool disposed;

        public StudentRepository(UniversityDbContext context)
        {
            this.context = context;
            this.disposed = false;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students.ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return this.context.Students.Find(studentId);
        }

        public void InsertStudent(Student student)
        {
            this.context.Students.Add(student);
        }

        public void DeleteStudent(int studentId)
        {
            Student student = this.context.Students.Find(studentId);
            if (student != null)
                this.context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            this.context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
