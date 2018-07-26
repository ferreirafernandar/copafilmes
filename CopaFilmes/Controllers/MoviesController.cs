using CopaFilmes.Models;
using CopaFilmes.Services;
using CopaFilmes.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopaFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class MoviesController : ControllerBase
    {
        private readonly ICopaFilmesService _copaFilmesService;

        public MoviesController(ICopaFilmesService copaFilmesService) => _copaFilmesService = copaFilmesService;

        [HttpGet]
        public ActionResult<IList<Movie>> Get()
        {
            return Ok(_copaFilmesService.GetMovies());
        }

        [HttpPost]
        [Route("game")]
        public ActionResult<Movie> Game(MovieViewModel movies)
        {
            if (movies.Movies.Count != 16) 
                return BadRequest("Escolha 16 filmes.");

            return Ok(_copaFilmesService.Game(movies.Movies));
        }
    }
}
