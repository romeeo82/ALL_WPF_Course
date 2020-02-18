using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    class Rating
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
        public int Stars { get; set; }
        public int NimberOfRaitings { get; set; }
    }
}
