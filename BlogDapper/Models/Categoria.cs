using System.ComponentModel.DataAnnotations;

namespace BlogDapper.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El nombre de categoria es obligatorio")]
        public string Nombre { get; set; }
        public DateTime FechaCreacion{ get; set; }

        //Esta indica la relación cpm articulo, donde una categoria puede tener muchos articulos.
        public List<Articulo> Articulo { get; set;}
    }
}
