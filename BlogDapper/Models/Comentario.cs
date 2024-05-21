using System.ComponentModel.DataAnnotations;

namespace BlogDapper.Models
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }
        [Required(ErrorMessage = "El Titulo de categoria es obligatorio")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "El mensaje debe tener minimo 10 caracteres y máximo 1000")]
        public string Mensaje { get; set; }

        public DateTime FechaCreacion { get; set; }

        //[Required(ErrorMessage = "El nombre de articulo es obligatorio")]
        public int ArticuloId { get; set; }

        public virtual Articulo Articulo { get; set; }  
      

    }
}
