using System.ComponentModel.DataAnnotations;

namespace VideoClub.Core.Entities
{
    public class MovieCopy
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual Movie? Movie { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}