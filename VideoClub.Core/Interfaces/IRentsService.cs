using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IRentsService
    {
        void AddMovieRent(MovieRent movieRent);
        IEnumerable<MovieRent> GetActiveMovieRents();
        IEnumerable<MovieRent> GetMovieRents();
        void ReturnMovie(int movieRentId);
    }
}
