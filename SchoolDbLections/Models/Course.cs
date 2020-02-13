using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDbLections.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public virtual IList<StudentCourse> StudentCourses { get; set; }
    }
}
