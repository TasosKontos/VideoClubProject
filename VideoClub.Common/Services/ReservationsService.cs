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
            var reservations = from r in _dbContext.Reservations
                               select r;

            reservations = reservations.Where(r => (r.To == null || r.To > DateTime.Now));

            return reservations.ToList();
        }

        public IEnumerable<Reservation> GetReservations()
        {
            var reservations = _dbContext.Reservations.AsEnumerable();
            return reservations;
        }
    }
}
