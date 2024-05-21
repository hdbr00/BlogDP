using System.ComponentModel.DataAnnotations;

namespace BlogDapper.Models
{
    public class Usuario
    {
        [Key]
        public Guid User_ID { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(20, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} carácteres. ", MinimumLength = 5)]
        public string Login { get; set; } //UserName

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(20, ErrorMessage = "El {0} debe ser al menos {2} y máximo {1} carácteres. ", MinimumLength = 6)]
        public string Password { get; set; } //
    }
}
