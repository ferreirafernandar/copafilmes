using CopaFilmes.Models;
using CopaFilmes.Utils;
using System.Collections.Generic;
using System.Linq;

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
            var groups = GetGroups(movies);
            var resultPlayoffs = Playoffs(groups);
            var resultQuarterFinals = Rounds(resultPlayoffs);
            var resultSemifinal = Rounds(resultQuarterFinals);
            var resultFinals = resultSemifinal.First();


            var first = resultFinals.GetWin();
            var second = resultFinals.GetLoser();

            var match = resultQuarterFinals.First(r => r.GetWin() == first);
            var third = match.GetLoser();

            var result = new List<Movie> { first, second, third };
            return result;
        }

        private static List<Group> GetGroups(List<Movie> movies)
        {
            const int countPerGroup = 4;
            const int countGroup = 4;

            var groups = new List<Group>();
            for (var i = 0; i < countGroup; i++)
            {
                var group = new Group(i, movies.GetRange(i * countPerGroup, countPerGroup));
                groups.Add(group);
            }
            return groups;
        }

        private static List<Match> Playoffs(List<Group> groups)
        {
            var matches = new List<Match>();

            for (var i = 0; i < groups.Count; i += 2)
            {
                var group1 = groups.ElementAt(i);
                var group2 = groups.ElementAt(i + 1);

                group1.GetTop(out var firstMovie1, out var secondMovie1);
                group2.GetTop(out var firstMovie2, out var secondMovie2);

                var match1 = new Match(firstMovie1, secondMovie2);
                var match2 = new Match(firstMovie2, secondMovie1);

                matches.Add(match1);
                matches.Add(match2);
            }
            return matches;
        }

        private static List<Match> Rounds(List<Match> matches)
        {
            var result = new List<Match>();

            for (var i = 0; i < matches.Count; i += 2)
            {
                var firstMatch = matches.ElementAt(i);
                var secondMatch = matches.ElementAt(i + 1);

                var match1 = new Match(firstMatch.GetWin(), secondMatch.GetWin());

                result.Add(match1);
            }
            return result;
        }
    }
}