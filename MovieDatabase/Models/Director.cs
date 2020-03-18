using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<MovieDirection> MovieDirections { get; set; }
    }
}
