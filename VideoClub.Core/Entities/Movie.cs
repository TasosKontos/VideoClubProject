using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoClub.Core.Enumerations;

namespace VideoClub.Core.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public ICollection<MovieCopy> Copies { get; set; } = new List<MovieCopy>();
    }
}