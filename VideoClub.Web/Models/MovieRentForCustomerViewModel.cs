using VideoClub.Core.Entities;

namespace VideoClub.Web.Models
{
    public class MovieRentForCustomerViewModel
    {
        public MovieRent? MovieRent { get; set; }
        public IEnumerable<Movie>? AvailableMovies { get; set; }
        public int SelectedMovieId { get; set; }
    }
}
