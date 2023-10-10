using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Core.Interfaces.Helpers;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class RentsService : IRentsService
    {
        private readonly ApplicationDbContext _dbContext;

        public RentsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMovieRent(MovieRent movieRent)
        {
            _dbContext.MovieRents.Add(movieRent);
            _dbContext.SaveChanges();
        }

        public IEnumerable<MovieRent> GetActiveMovieRents()
        {
            var rents = _dbContext.MovieRents.AsQueryable();

            rents = rents.Where(r => (r.To == null || r.To > DateTime.Now));
            var rentsList = rents.ToList();
            foreach (var rent in rentsList)
            {
                _dbContext.Entry(rent).Reference(r => r.ApplicationUser).Load();
                _dbContext.Entry(rent).Reference(r=>r.MovieCopy).Load();
                _dbContext.Entry(rent.MovieCopy).Reference(mc=>mc.Movie).Load();
            }
            return rentsList;
        }

        public IEnumerable<MovieRent> GetMovieRents()
        {
            var rents = _dbContext.MovieRents.AsEnumerable();
            foreach (var rent in rents)
            {
                _dbContext.Entry(rent).Reference(r => r.ApplicationUser).Load();
                _dbContext.Entry(rent).Reference(r => r.MovieCopy).Load();
                _dbContext.Entry(rent.MovieCopy).Reference(mc => mc.Movie).Load();
            }
            return rents;
        }

        public void ReturnMovie(int rentId)
        {
            var rent = _dbContext.MovieRents.Find(rentId);
            rent.To = DateTime.Now;
            _dbContext.SaveChanges();
        }
    }
}
