using System.Collections.Generic;
using CopaFilmes.Models;
using CopaFilmes.Services;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ICopaFilmesService _copaFilmesService;

        public MoviesController(ICopaFilmesService copaFilmesService) => _copaFilmesService = copaFilmesService;

        [HttpGet]
        public IList<Movie> Get()
        {
            return _copaFilmesService.GetMovies();
        }

        [HttpPost]
        public List<Movie> Game(List<Movie> movies)
        {
            return _copaFilmesService.Game(movies);
        }
    }
}
