using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LiteraryWings.EntidadesDeNegocio
{
    public class Libro
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Autor")]
        [Required(ErrorMessage = "El Autor es obligatorio")]
        [Display(Name = "Autor")]
        public int IdAutor { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "La Categoria es obligatoria")]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("Editorial")]
        [Required(ErrorMessage = "El Editorial es obligatorio")]
        [Display(Name = "Editorial")]
        public int IdEditorial { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Fecha de Lanzamiento es obligatoria")]
        [Display(Name = "Fecha de Lanzamiento ")]
        public string FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El Idioma es obligatorio")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Idioma { get; set; }

        [Required(ErrorMessage = "Las Paginas es obligatoria")]
        public int Paginas { get; set; }

        [Required(ErrorMessage = "La Descripcion es obligatoria")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Imagen de Portada es obligatoria")]
        [Display(Name = "Imagen de Portada")]
        public string ImagenPortada { get; set; }

        [Required(ErrorMessage = "El Link de Descarga es obligatorio")]
        [Display(Name = "Link de Descarga")]
        public string LinkDescarga { get; set; }

        [Required(ErrorMessage = "La Imagen de Introduccion es obligatoria")]
        [Display(Name = "Imagen de Introduccion")]
        public string ImagenIntroduccion { get; set; }


        //propiedad de navegación
        [ValidateNever]
        public Autor Autor { get; set; }

        [ValidateNever]
        public Categoria Categoria { get; set; }

        [ValidateNever]
        public Editorial Editorial { get; set; }

        //propiedades auxiliares
        [NotMapped]
        public int top_aux { get; set; }

    }
}
