using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabase.Models
{
    class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("JOB_ID")]
        [MaxLength(10)]
        public string Id { get; set; }

        [Column("JOB_TITLE")]
        [MaxLength(35)]
        public string JobTitle { get; set; }

        [Column("MIN_SALARY")]
        public decimal SalaryMin { get; set; }

        [Column("MAX_SALARY")]
        public decimal SalaryMax { get; set; }

        public List<JobHistory> JobHistories { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
