using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoClub.Core.Entities
{
    public class MovieRent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public String? Comments { get; set; }
        [Required]
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; } = null;
        [Required]
        public int MovieCopyId { get; set; }
        [ForeignKey("MovieCopyId")]
        public MovieCopy MovieCopy { get; set; } = null!;
    }
}