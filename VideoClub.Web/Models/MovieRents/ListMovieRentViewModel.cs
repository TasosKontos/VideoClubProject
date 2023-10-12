namespace VideoClub.Web.Models.MovieRents
{
    public class ListMovieRentViewModel
    {
        public int Id { get; set; }
        public string MovieCopyMovieTitle { get; set; }
        public int MovieCopyId { get; set; }
        public string ApplicationUserUsername { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public  string Comments { get; set; }
    }
}
