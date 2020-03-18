using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabase.Models
{
    class Region
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("REGION_ID")]
        public int Id { get; set; }

        [Column("REGION_NAME")]
        [MaxLength(25)]
        public string Name { get; set; }

        public List<Country> Countries { get; set; }
    }
}
