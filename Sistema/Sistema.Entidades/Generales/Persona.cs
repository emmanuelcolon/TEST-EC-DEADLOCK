using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Generales
{
    public class Persona
    {
        public int PersonaId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 255 caracteres, ni menos de 3 caracteres.")]
        public string NombreCompleto { get; set; }
        [Required]
        public int PosicionTrabajoId { get; set; }

        public virtual Posicion_Trabajo Posicion_Trabajos { get; set; }
    }
}
