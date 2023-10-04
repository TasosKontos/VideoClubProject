using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Enumerations;
using VideoClub.Core.Interfaces;
using VideoClub.Core.Interfaces.Helpers;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<MovieWCount> GetAllMoviesWithCount(string titleSearch, string genreFilter)
        {
            IQueryable<Movie> movies = _dbContext.Movies.AsQueryable();

            movies = from m in _dbContext.Movies
                     select m;

            if (!String.IsNullOrEmpty(titleSearch))
            {
                movies = movies.Where(m => m.Title.Contains(titleSearch));
            }

            if (!String.IsNullOrEmpty(genreFilter))
            {
                Genre genre;
                Enum.TryParse<Genre>(genreFilter, out genre);
                movies = movies.Where(m => m.Genre == genre);
            }

            var moviesWithAvailableCopiesCount = movies.Select(movie => new MovieWCount
            {
                movie = movie,
                availableCopyCount = (movie.Copies.Count(copy =>
                copy.Reservations.All(reservation =>
                reservation.To != null && reservation.To < DateTime.Now))
                +
                movie.Copies.Count(copy => copy.Reservations.Count == 0))
            });

            return moviesWithAvailableCopiesCount;
        }

        public IEnumerable<Movie> GetAvailableMovies()
        {
            var movies = _dbContext.Movies.AsQueryable();

            movies = movies.Where(movie => (movie.Copies.Any(copy =>
                copy.Reservations.All(reservation =>
                reservation.To != null && reservation.To < DateTime.Now))));

            return movies;
        }

        public Movie FindMovieById(int movieId)
        {
            var movie = _dbContext.Movies.Where(m => m.Id == movieId);
            return movie.FirstOrDefault();
        }
    }
}
