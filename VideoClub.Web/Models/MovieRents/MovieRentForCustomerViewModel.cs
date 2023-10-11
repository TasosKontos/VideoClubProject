using NuGet.Protocol.Core.Types;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces.Helpers;

namespace VideoClub.Web.Models.MovieRents
{
    public class MovieRentForCustomerViewModel
    {
        public string ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public string Comments { get; set; }
        //public MovieRent? MovieRent { get; set; }
        public IEnumerable<MovieForView> AvailableMovies { get; set; }
        public int SelectedMovieId { get; set; }
    }
}
