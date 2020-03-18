using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
