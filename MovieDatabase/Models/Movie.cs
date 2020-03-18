using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Models
{
    class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Country { get; set; }
        public List<MovieCast> MovieCasts { get; set; }
        public List<MovieDirection> MovieDirections { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
