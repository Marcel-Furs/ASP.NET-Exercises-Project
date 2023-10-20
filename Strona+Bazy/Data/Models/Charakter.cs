using System.ComponentModel.DataAnnotations;

namespace Strona_Bazy.Data.Models
{
    public class Charakter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Weapon { get; set; }

        [Required]
        public int? Damage { get; set; }
    }
}
