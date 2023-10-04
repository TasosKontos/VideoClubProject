using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VideoClub.Web.Models
{
    public class LogInModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [HiddenInput]
        public string? ReturnUrl { get; set; }
    }
}
