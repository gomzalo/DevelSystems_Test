using System;
using System.Collections.Generic;

namespace Back.Models
{
    public partial class Respuestum
    {
        public string NombrePregunta { get; set; } = null!;
        public string NombreEncuesta { get; set; } = null!;
        public string Respuesta { get; set; } = null!;

        public virtual Preguntum Nombre { get; set; } = null!;
    }
}
