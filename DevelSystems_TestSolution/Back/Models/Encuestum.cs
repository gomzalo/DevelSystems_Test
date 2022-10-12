using System;
using System.Collections.Generic;

namespace Back.Models
{
    public partial class Encuestum
    {
        public Encuestum()
        {
            Pregunta = new HashSet<Preguntum>();
        }

        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Link { get; set; }

        public virtual ICollection<Preguntum> Pregunta { get; set; }
    }
}
