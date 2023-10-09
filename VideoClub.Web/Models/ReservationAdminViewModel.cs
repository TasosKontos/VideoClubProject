using VideoClub.Core.Entities;

namespace VideoClub.Web.Models
{
    public class ReservationAdminViewModel
    {
        public DateTime From {  get; set; }
        public DateTime To { get; set; }
        public int MovieId { get; set; }
        public int MovieCopyId { get; set; }
        public string? Username { get; set; }
        public string? Comments { get; set; }
    }
}
