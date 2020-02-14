using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabase.Models
{
    class JobHistory
    {
        [Key]
        [Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }
        [Key]
        [Column("START_DATE")]
        public DateTime HiredDate { get; set; }
        public List<Employee> Employees { get; set; }

        [Column("END_DATE")]
        public DateTime EndDate { get; set; }

        [Column("JOB_ID")]
        [MaxLength(10)]
        public string JobId { get; set; }
        public Job Job { get; set; }

        [Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
