using System.Collections.Generic;
using MvvmExample.DAL.Model;

namespace MvvmExample.DAL.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        void SaveStudents();
        void DeleteStudent(Student student);
        void DeleteBook(int studentId, Book book);
    }
}