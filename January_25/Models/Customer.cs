using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January_25.Models
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
