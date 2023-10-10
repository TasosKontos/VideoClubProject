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
    public class ReservationsService : IReservationService
    {
        private readonly ApplicationDbContext _dbContext;

        public ReservationsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddReservation(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Reservation> GetActiveReservations()
        {
            var reservations = _dbContext.Reservations.AsQueryable();

            reservations = reservations.Where(r => (r.To == null || r.To > DateTime.Now));
            var reservationsList = reservations.ToList();
            foreach (var reservation in reservationsList)
            {
                _dbContext.Entry(reservation).Reference(r => r.ApplicationUser).Load();
                _dbContext.Entry(reservation).Reference(r=>r.MovieCopy).Load();
                _dbContext.Entry(reservation.MovieCopy).Reference(mc=>mc.Movie).Load();
            }
            return reservationsList;
        }

        public IEnumerable<Reservation> GetReservations()
        {
            var reservations = _dbContext.Reservations.AsEnumerable();
            foreach (var reservation in reservations)
            {
                _dbContext.Entry(reservation).Reference(r => r.ApplicationUser).Load();
                _dbContext.Entry(reservation).Reference(r => r.MovieCopy).Load();
                _dbContext.Entry(reservation.MovieCopy).Reference(mc => mc.Movie).Load();
            }
            return reservations;
        }

        public void ReturnMovie(int reservationId)
        {
            var reservation = _dbContext.Reservations.Find(reservationId);
            reservation.To = DateTime.Now;
            _dbContext.SaveChanges();
        }
    }
}
