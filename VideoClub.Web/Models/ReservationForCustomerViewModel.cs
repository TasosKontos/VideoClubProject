using VideoClub.Core.Entities;

namespace VideoClub.Web.Models
{
    public class ReservationForCustomerViewModel
    {
        public Reservation? Reservation { get; set; }
        public IEnumerable<Movie>? AvailableMovies { get; set; }
        public int SelectedMovieId { get; set; }
    }
}
