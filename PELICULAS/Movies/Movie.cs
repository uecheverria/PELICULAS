using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PELICULAS.Modelos
{
    public class Movie
    {
        public int ID { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [DataType(DataType.Date)] //Convertir objeto DateTime a Date
        [Display(Name = "Fecha de lanzamiento")]
        public DateTime ReleaseDate { get; set; }
        
        [Display(Name = "Género")]
        public string Genre { get; set; }

        [Column(TypeName="decimal(18,2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Precio (€)")]
        public decimal Price { get; set; }
    }
}
