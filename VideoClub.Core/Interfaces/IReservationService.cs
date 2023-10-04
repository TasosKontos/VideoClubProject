using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IReservationService
    {
        void AddReservation(Reservation reservation);
        IEnumerable<Reservation> GetActiveReservations();
        IEnumerable<Reservation> GetReservations();
    }
}
