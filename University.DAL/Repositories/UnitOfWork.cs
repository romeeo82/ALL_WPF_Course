using System;
using System.Collections.Generic;
using System.Text;
using University.DAL.Models;

namespace University.DAL.Repositories
{
    public class UnitOfWork:IDisposable
    {
        private UniversityDbContext context = new UniversityDbContext();
        private GenericRepository<Student> studenttRepository;
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<Course> courseRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studenttRepository == null)
                    this.studenttRepository = new GenericRepository<Student>(context);
                return studenttRepository;
            }
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                    this.departmentRepository = new GenericRepository<Department>(context);
                return departmentRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if (this.courseRepository == null)
                    this.courseRepository = new GenericRepository<Course>(context);
                return courseRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
