using System;
using System.Collections.Generic;

namespace Back.Models.DB
{
    public partial class Encuestum
    {
        public Encuestum()
        {
            Pregunta = new HashSet<Preguntum>();
            Respuesta = new HashSet<Respuestum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? Link { get; set; }

        public virtual ICollection<Preguntum> Pregunta { get; set; }
        public virtual ICollection<Respuestum> Respuesta { get; set; }
    }
}
