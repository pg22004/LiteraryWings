using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LiteraryWings.EntidadesDeNegocio
{
    public class Autor
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La Fecha de nacimiento es obligatoria")]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La imagen es obligatoria")]
        [Display(Name = "Imagen del Autor")]
        public string AutorImagen { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Libro> Libro { get; set; }
    }
}
