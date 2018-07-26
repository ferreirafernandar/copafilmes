﻿using System.Collections.Generic;
using CopaFilmes.Models;
using CopaFilmes.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<Movie> Game(Movies movies)
        {
            if (movies.Movie.Count != 16) 
                return BadRequest("Escolha 16 filmes.");

            return Ok(_copaFilmesService.Game(movies.Movie));
        }
    }
}
