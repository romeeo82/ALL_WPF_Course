using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabaseFluentApi.Models
{
    class Job
    {
        public string Id { get; set; }
        public string JobTitle { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public List<JobHistory> JobHistories { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
