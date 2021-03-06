﻿using System;

namespace CopaFilmes.Models
{
    public class Match
    {
        public Movie MovieA { get; }
        public Movie MovieB { get; }

        public Match(Movie movieA, Movie movieB)
        {
            MovieA = movieA;
            MovieB = movieB;
        }

        public Movie GetWin()
        {
            if (MovieA.AverageRating > MovieB.AverageRating)
                return MovieA;

            if (MovieB.AverageRating > MovieA.AverageRating)
                return MovieB;

            return string.Compare(MovieA.PrimaryTitle, MovieB.PrimaryTitle, StringComparison.Ordinal) >= 0 ? MovieB : MovieA;
        }

        public Movie GetLoser()
        {
            if (MovieA.AverageRating > MovieB.AverageRating)
                return MovieB;

            if (MovieB.AverageRating > MovieA.AverageRating)
                return MovieA;

            return string.Compare(MovieA.PrimaryTitle, MovieB.PrimaryTitle, StringComparison.Ordinal) >= 0 ? MovieA : MovieB;
        }
    }
}