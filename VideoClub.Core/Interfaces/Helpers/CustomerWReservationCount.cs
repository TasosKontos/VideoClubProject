using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces.Helpers
{
    public class CustomerWReservationCount
    {
        public ApplicationUser? customer;
        public int activeReservations;
    }
}
