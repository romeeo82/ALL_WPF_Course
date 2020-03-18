using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabaseFluentApi.Models
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiredDate { get; set; }
        public string JobId { get; set; }
        public Job Job { get; set; }
        public JobHistory JobHistory { get; set; }
        public decimal Salary { get; set; }
        public decimal CommissionPct { get; set; }
        public int ManagerId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
