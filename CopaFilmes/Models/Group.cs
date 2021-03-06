﻿using CopaFilmes.Utils;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Models
{
    public class Group
    {
        public string Name { get; }
        public List<Movie> Movies { get; }

        public Group(int index, IEnumerable<Movie> movies)
        {
            Name = NumberToLetterUtil.GetName(index);
            Movies = movies.OrderByDescending(m => m.AverageRating).ThenBy(m => m.PrimaryTitle).ToList();
        }

        public void GetTop(out Movie firstMovie, out Movie secondMovie)
        {
            firstMovie = Movies.First();
            secondMovie = Movies.ElementAt(1);
        }
    }
}