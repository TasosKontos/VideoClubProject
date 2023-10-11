using System.ComponentModel.DataAnnotations;

namespace VideoClub.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
