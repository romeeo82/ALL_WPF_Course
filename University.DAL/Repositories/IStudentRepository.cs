using System;
using System.Collections.Generic;
using System.Text;
using University.DAL.Models;

namespace University.DAL.Repositories
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        void Save();

    }
}
