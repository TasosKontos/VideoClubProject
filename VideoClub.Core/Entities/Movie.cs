using System.ComponentModel.DataAnnotations;
using VideoClub.Core.Enumerations;

namespace VideoClub.Core.Entities
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public virtual ICollection<MovieCopy> Copies { get; set; } = new List<MovieCopy>();
    }
}