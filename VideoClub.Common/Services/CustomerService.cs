using Microsoft.AspNetCore.Identity;
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
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;

        public CustomerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<CustomerWReservationCount> GetAllCustomersWithReservationCount()
        {
            var customers = from user in _db.Users
                            join userRole in _db.UserRoles on user.Id equals userRole.UserId
                            join role in _db.Roles on userRole.RoleId equals role.Id
                            where role.Name == "User"
                            select user;

            var customersWithActiveReservationCount =
                customers.Select(customer => new CustomerWReservationCount
                {
                    customer = customer,
                    activeReservations = customer.Reservations.Count(reservation =>
                        reservation.To == null || reservation.To > DateTime.Now)
                });

            return customersWithActiveReservationCount;
        }

        public IEnumerable<Reservation> GetReservationsForCustomerId(string customerId)
        {
            IEnumerable<Reservation> reservations = _db.Users.Where(u => u.Id == customerId).SelectMany(u => u.Reservations).ToList();
            foreach (var reservation in reservations) {
                _db.Entry(reservation).Reference(r => r.ApplicationUser).Load();
                _db.Entry(reservation).Reference(r => r.MovieCopy).Load();
                _db.Entry(reservation.MovieCopy).Reference(cp => cp.Movie).Load();
            }
            return reservations;
        }

    }
}
