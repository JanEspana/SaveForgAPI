using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrogGameAPI.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; } // Clau primària
        [Required]
        public int Time { get; set; } // Obligatori
        [Required]
        public int NumFlies { get; set; } // Obligatori
        [Required]
        public string Character { get; set; } // Obligatori
        [Required]
        public string Username { get; set; } // Obligatori
    }
}
