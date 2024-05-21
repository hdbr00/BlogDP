using System.ComponentModel.DataAnnotations;

namespace BlogDapper.Models
{
    public class Slider
    {
        [Key]
        public int IdSlider { get; set; }
        [Required(ErrorMessage ="El nombre de Slider es obligatorio")]
        public string Nombre { get; set; }
        public string UrlImagen { get; set; }
    }
}
