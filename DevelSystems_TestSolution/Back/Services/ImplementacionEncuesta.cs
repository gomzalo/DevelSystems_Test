

using Back.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Back.Services
{
    public class ImplementacionEncuesta : InterfaceEncuesta
    {
        ENCUESTAS_DSContext _context;
        public ImplementacionEncuesta(ENCUESTAS_DSContext context)
        {
            _context = context;
        }

        public string addEncuesta(Encuestum encuesta)
        {
            try {
                _context.Encuesta.Add(encuesta);
                _context.SaveChanges();
                return "https://localhost:7249/api/Encuesta/?name=" + encuesta.Nombre;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public bool addRespuesta(Respuestum respuesta)
        {
            try
            {
                _context.Respuesta.Add(respuesta);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool delEncuesta(string nombre)
        {
            try
            {
                Encuestum encuesta = _context.Encuesta.Where(e => e.Nombre == nombre).FirstOrDefault();
                _context.Encuesta.Remove(encuesta);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //throw e;
                return false;
            }
        }

        public Encuestum getEncuesta(string nombre)
        {
            try
            {
                return _context.Encuesta.Where(e => e.Nombre == nombre).FirstOrDefault();
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }

        public IEnumerable<Encuestum> getEncuestas()
        {
            try
            {
                return _context.Encuesta.ToList();
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }

        public IEnumerable<Respuestum> getRespuestas(string nombre)
        {
            try
            {
                return (IEnumerable<Respuestum>)_context.Respuesta.Where(e => e.NombreEncuesta == nombre).FirstOrDefault();
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }

        public bool updateEncuesta(Encuestum encuesta)
        {
            try
            {
                Encuestum encuestaAntigua = _context.Encuesta.Where(e => e.Nombre == encuesta.Nombre).Include(e => e.Pregunta).FirstOrDefault();

                encuestaAntigua.Descripcion = encuesta.Descripcion;
                encuestaAntigua.Pregunta = encuesta.Pregunta;
                _context.Update(encuestaAntigua);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }
    }
}
