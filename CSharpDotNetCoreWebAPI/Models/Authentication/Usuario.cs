using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Authentication
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(Order = 2)]
        [MaxLength(50), MinLength(5)]
        public string Username { get; set; }
        [Required]
        [Column(Order = 3)]
        [MaxLength(15), MinLength(6)]
        public string Password { get; set; }
        [Column(Order = 4)]
        public string Role { get; set; }
    }
}
