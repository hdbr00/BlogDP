using System.ComponentModel.DataAnnotations;

namespace BlogDapper.Models
{
    public class Articulo
    {
        public Articulo()
        {

            Etiqueta = new List<Etiqueta>();
        }

        [Key]
        public int IdArticulo { get; set; }
        [Required(ErrorMessage ="El Titulo de categoria es obligatorio")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(1000,MinimumLength =10,ErrorMessage ="La descripción debe tener minimo 10 caracteres y máximo 1000")]
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        [Required(ErrorMessage = "El nombre de categoria es obligatorio")]
        public int CategoriaId { get; set; }

        //Esta indica la relacion con categoria de que un articulo debe pertenecer a uno sola categoria.
        public virtual Categoria Categoria { get; set;}

        //Un articulo puede recibir o tener muchos comentarios.
        public List<Comentario> comentarios { get; set; }

        public List<Etiqueta> Etiqueta { get; set;}

    }
}
