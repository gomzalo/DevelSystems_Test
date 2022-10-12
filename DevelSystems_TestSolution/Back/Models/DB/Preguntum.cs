using System;
using System.Collections.Generic;

namespace Back.Models.DB
{
    public partial class Preguntum
    {
        public Preguntum()
        {
            Respuesta = new HashSet<Respuestum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string? Tipo { get; set; }
        public string? Requerido { get; set; }
        public int? IdEncuesta { get; set; }

        public virtual Encuestum? IdEncuestaNavigation { get; set; }
        public virtual ICollection<Respuestum> Respuesta { get; set; }
    }
}
