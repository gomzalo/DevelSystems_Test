using System;
using System.Collections.Generic;

#nullable disable
namespace Back.Models
{
    public partial class Preguntum
    {
        public string Nombre { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string? Tipo { get; set; }
        public string? Requerido { get; set; }
        public string NombreEncuesta { get; set; } = null!;

        public virtual Encuestum NombreEncuestaNavigation { get; set; } = null!;
        public virtual Respuestum? Respuestum { get; set; }
    }
}
