using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class CopiesService : ICopiesService
    {
        private readonly ApplicationDbContext _dbContext;

        public CopiesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MovieCopy GetAvailableCopyForMovieId(int movieId)
        {
            var copies = from c in _dbContext.MovieCopies
                         where movieId == c.Movie.Id
                         select c;

            copies = copies.Where(copy =>
                        copy.Reservations.All((reservation =>
                         reservation.To != null && reservation.To < DateTime.Now)) || copy.Reservations.Count == 0);

            return copies.FirstOrDefault();
        }

        public MovieCopy GetMovieCopyById(int copyId)
        {
            return _dbContext.MovieCopies.Find(copyId);
        }
    }
}
