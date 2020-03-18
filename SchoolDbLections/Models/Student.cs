using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDbLections.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentGradeId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual StudentAddress Address { get; set; }
        public virtual IList<StudentCourse> StudentCourses { get; set; } 
    }
}
