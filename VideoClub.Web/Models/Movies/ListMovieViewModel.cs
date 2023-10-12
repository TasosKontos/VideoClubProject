using VideoClub.Core.Enumerations;

namespace VideoClub.Web.Models.Movies
{
    public class ListMovieViewModel
    {
        public int MovieId { get; set; }
        public Genre MovieGenre { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public int availableCopyCount { get; set; }
    }
}
