using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces.Helpers;

namespace VideoClub.Core.Interfaces
{
    public interface ICustomerService
    {
        IQueryable<CustomerWMovieRentCount> GetAllCustomersWithMovieRentCount();
        IEnumerable<MovieRent> GetMovieRentsForCustomerId (string customerId);
    }
}
