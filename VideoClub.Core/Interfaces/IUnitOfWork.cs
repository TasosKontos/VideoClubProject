using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICopiesService Copy { get; }
        IMoviesService Movie { get; }
        IReservationService Reservation { get; }
        ICustomerService Customer { get; }
        IUsersService User { get; }
        void Save();
    }
}
