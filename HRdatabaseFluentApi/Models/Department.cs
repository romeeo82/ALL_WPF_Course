using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabaseFluentApi.Models
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public List<Employee> Employees { get; set; }
        public List<JobHistory> JobHistories { get; set; }
    }
}
