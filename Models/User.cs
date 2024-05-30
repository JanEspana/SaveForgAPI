using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrogGameAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; } // Clau primaria
        [Required]
        public string Password { get; set; } // Obligatori
    }
}
