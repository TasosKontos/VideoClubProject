using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Movie = new MoviesService(_db);
            Copy = new CopiesService(_db);
            Reservation = new ReservationsService(_db);
            Customer = new CustomerService(_db);
            User = new UsersService(_db);
        }
        public IMoviesService Movie { get; private set; }
        public ICopiesService Copy { get; private set; }
        public IReservationService Reservation { get; private set; }
        public IUsersService User { get; private set; }
        public ICustomerService Customer { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
