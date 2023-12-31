﻿using Microsoft.AspNetCore.Identity;
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

        public IQueryable<CustomerWMovieRentCount> GetAllCustomersWithMovieRentCount()
        {
            //var customers = from user in _db.Users
            //                join userRole in _db.UserRoles on user.Id equals userRole.UserId
            //                join role in _db.Roles on userRole.RoleId equals role.Id
            //                where role.Name == "User"
            //                select user;

            var customers = _db.Users
                            .Join(_db.UserRoles, user => user.Id, userRole => userRole.UserId, (user, userRole) => new { user, userRole })
                            .Join(_db.Roles, ur => ur.userRole.RoleId, role => role.Id, (ur, role) => new { ur.user, role })
                            .Where(joined => joined.role.Name == "User")
                            .Select(joined => joined.user);
                      

            var customersWithActiveReservationCount =
                customers.Select(customer => new CustomerWMovieRentCount
                {
                    customer = customer,
                    activeMovieRents = customer.MovieRents.Count(reservation =>
                        reservation.To == null || reservation.To > DateTime.Now)
                });

            return customersWithActiveReservationCount;
        }

        public IEnumerable<MovieRent> GetMovieRentsForCustomerId(string customerId)
        {
            IEnumerable<MovieRent> rents = _db.Users.Where(u => u.Id == customerId).SelectMany(u => u.MovieRents).ToList();
            foreach (var rent in rents) {
                _db.Entry(rent).Reference(r => r.ApplicationUser).Load();
                _db.Entry(rent).Reference(r => r.MovieCopy).Load();
                _db.Entry(rent.MovieCopy).Reference(cp => cp.Movie).Load();
            }
            return rents;
        }

    }
}
