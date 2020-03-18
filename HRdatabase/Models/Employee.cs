using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabase.Models
{
    class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EMPLOYEE_ID")]
        public int Id { get; set; }

        [Column("FIRST_NAME")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Column("LAST_NAME")]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Column("EMAIL")]
        [MaxLength(25)]
        public string Email { get; set; }

        [Column("PHONE_NUMBER")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Column("HIRE_DATE")]
        public DateTime HiredDate { get; set; }

        [Column("JOB_ID")]
        [MaxLength(10)]
        public string JobId { get; set; }
        public Job Job { get; set; }
        public JobHistory JobHistory { get; set; }

        [Column("SALARY")]
        public decimal Salary { get; set; }

        [Column("COMMISSION_PCT")]
        public decimal CommissionPct { get; set; }

        [Column("MANAGER_ID")]
        public int ManagerId { get; set; }

        [Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
