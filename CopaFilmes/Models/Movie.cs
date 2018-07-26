using System.Collections.Generic;

namespace CopaFilmes.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string PrimaryTitle { get; set; }
        public string Year { get; set; }
        public decimal AverageRating { get; set; }
    }
}