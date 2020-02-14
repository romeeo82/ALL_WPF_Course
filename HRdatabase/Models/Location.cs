using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRdatabase.Models
{
    class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("LOCATION_ID")]
        public int Id { get; set; }

        [Column("STREET_ADDRESS")]
        [MaxLength(25)]
        public string StreetAddress { get; set; }

        [Column("POSTAL_CODE")]
        [MaxLength(12)]
        public string PostalCode { get; set; }

        [Column("CITY")]
        [MaxLength(30)]
        public string City { get; set; }

        [Column("STATE_PROVINCE")]
        [MaxLength(12)]
        public string StateProvince { get; set; }

        [Column("COUNTRY_ID")]
        [MaxLength(2)]
        public string CountryId  { get; set; }
        public Country Country { get; set; }

        public List<Department> Departments { get; set; }
    }
}
