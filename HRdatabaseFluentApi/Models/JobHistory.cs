using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabaseFluentApi.Models
{
    class JobHistory
    {
        public int EmployeeId { get; set; }
        public DateTime HiredDate { get; set; }
        public List<Employee> Employees { get; set; }
        public DateTime EndDate { get; set; }
        public string JobId { get; set; }
        public Job Job { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
