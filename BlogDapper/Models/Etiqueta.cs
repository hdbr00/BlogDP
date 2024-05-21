﻿using System.ComponentModel.DataAnnotations;

namespace BlogDapper.Models
{
    public class Etiqueta
    {

        public Etiqueta()
        {
            Articulo = new List<Articulo>();
        }

        [Key]
        public int IdEtiqueta { get; set; }
        [Required(ErrorMessage = "El nombre de la etiqueta es obligatorio")]
        public string NombreEtiqueta { get; set; }
        public DateTime FechaCreacion { get; set; }


        //Esta indica la relación con articulo, con una tabla intermedia  articuloEtiqueta. 
        public List<Articulo> Articulo { get; set; }


    }
}
