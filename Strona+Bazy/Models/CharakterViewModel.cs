using System.ComponentModel.DataAnnotations;

namespace Strona_Bazy.Models
{
    public class CharakterViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Weapon { get; set; }

        [Required]
        public int? Damage { get; set; }
    }
}
