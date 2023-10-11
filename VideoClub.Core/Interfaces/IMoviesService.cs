using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces.Helpers;

namespace VideoClub.Core.Interfaces
{
    public interface IMoviesService
    {
        IQueryable<MovieWCount> GetAllMoviesWithCount(string titleSearch, string genreFilter);
        IEnumerable<MovieForView> GetAvailableMovies();
        Movie FindMovieById(int movieId);
    }
}
