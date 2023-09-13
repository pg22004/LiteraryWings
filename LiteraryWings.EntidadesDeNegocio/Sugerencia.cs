using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.EntidadesDeNegocio
{
    public class Sugerencia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(30, ErrorMessage = "El largo máximo es de 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [MaxLength(35, ErrorMessage = "El largo máximo es de 35 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El comentario es obligatoria")]
        public string Comentario { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
