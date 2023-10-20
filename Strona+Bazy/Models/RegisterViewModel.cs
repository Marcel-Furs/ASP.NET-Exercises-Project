using System.ComponentModel.DataAnnotations;

namespace Strona_Bazy.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "Password confirmation")]
        public string Password2 { get; set; }
    }
}
