using System;
using System.Collections.Generic;

namespace Back.Models.DB
{
    public partial class Respuestum
    {
        public int Id { get; set; }
        public int? IdPregunta { get; set; }
        public int? IdEncuesta { get; set; }
        public string Respuesta { get; set; } = null!;

        public virtual Encuestum? IdEncuestaNavigation { get; set; }
        public virtual Preguntum? IdPreguntaNavigation { get; set; }
    }
}
