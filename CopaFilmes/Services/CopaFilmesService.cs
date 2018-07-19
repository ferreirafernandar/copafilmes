using CopaFilmes.Models;
using CopaFilmes.Utils;
using System.Collections.Generic;

namespace CopaFilmes.Services
{
    public class CopaFilmesService : ICopaFilmesService
    {
        private readonly IHttpClient _httpClient;
        private static IList<Movie> _movie;


        public CopaFilmesService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public T GetBaseHttpTask<T>(string endpoint)
        {
            return _httpClient.GetBaseHttpTask<T>(Singleton.AppSettings.BaseUrl, endpoint);
        }

        public IList<Movie> GetMovies()
        {
            if (_movie != null)
                return _movie;

            _movie = GetBaseHttpTask<IList<Movie>>("filmes");

            return _movie;
        }

        public List<Movie> Game(List<Movie> movies)
        {
            //grupos
            var groups = GetGroups(movies);
        }

        private static IEnumerable<Group> GetGroups(List<Movie> movies)
        {
            const int countPerGroup = 4;
            const int countGroup = 4;

            var groups = new List<Group>();
            for (var i = 0; i < countGroup; i++)
            {
                var group = new Group(i.ToString(), movies.GetRange(i * countPerGroup, countPerGroup));
                groups.Add(group);
            }

            return groups;
        }
    }
}