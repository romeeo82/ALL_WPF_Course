using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabase.Models
{
    class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DEPARTMENT_ID")]
        public int Id { get; set; }

        [Column("DEPARTMENT_NAME")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column("MANAGER_ID")]
        public int ManagerId { get; set; }

        [Column("LOCATION_ID")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public List<Employee> Employees { get; set; }

        public List<JobHistory> JobHistories { get; set; }
    }
}
