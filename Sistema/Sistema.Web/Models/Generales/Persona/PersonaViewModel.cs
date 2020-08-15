using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Generales.Persona
{
    public class PersonaViewModel
    {
        public int PersonaId { get; set; }
        public string NombreCompleto { get; set; }
        public int PosicionTrabajoId { get; set; }
        public string NombrePosicionTrabajo { get; set; }
    }
}
