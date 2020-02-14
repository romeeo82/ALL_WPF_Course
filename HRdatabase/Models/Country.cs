using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabase.Models
{
    class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("COUNTRY_ID")]
        [MaxLength(2)]
        public string Id { get; set; }

        [Column("REGION_NAME")]
        [MaxLength(25)]
        public string Name { get; set; }

        [Column("REGION_ID")]
        public int RegionId { get; set; }
        public Region Region { get; set; }

        public List<Location> Locations { get; set; }
    }
}
