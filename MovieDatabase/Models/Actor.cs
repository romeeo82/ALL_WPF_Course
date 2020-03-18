using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public List<MovieCast> MovieCasts { get; set; }
    }
}
