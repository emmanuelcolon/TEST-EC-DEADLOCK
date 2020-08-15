using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Generales
{
    public class Posicion_Trabajo
    {
        public int PosicionTrabajoId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 255 caracteres, ni menos de 3 caracteres.")]
        public string Nombre { get; set; }

    }
}
