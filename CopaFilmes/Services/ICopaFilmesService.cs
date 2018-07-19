using CopaFilmes.Models;
using System.Collections.Generic;

namespace CopaFilmes.Services
{
    public interface ICopaFilmesService
    {
        IList<Movie> GetMovies();
        List<Movie> Game(List<Movie> movies);
    }
}