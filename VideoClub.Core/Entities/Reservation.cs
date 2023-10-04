namespace VideoClub.Core.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public String? Comments { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public virtual MovieCopy? MovieCopy { get; set; }
    }
}