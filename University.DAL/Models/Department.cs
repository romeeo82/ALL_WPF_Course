using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
