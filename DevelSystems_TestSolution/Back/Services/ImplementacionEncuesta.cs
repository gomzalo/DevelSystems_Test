using Back.Models.DB;
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
                string link = "https://localhost:4200/encuesta?id=" + encuesta.Id;
                encuesta.Link = link;
                _context.Update(encuesta);
                _context.SaveChanges();
                return link;
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
                //_context.Encuesta.Where(e => e.Id == respuesta.id).Include(e => e.Pregunta).FirstOrDefault();
                _context.Respuesta.Add(respuesta);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool delEncuesta(int id)
        {
            try
            {
                Encuestum encuesta = _context.Encuesta.Where(e => e.Id == id).FirstOrDefault();
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

        public Encuestum getEncuesta(int id)
        {
            try
            {
                return _context.Encuesta.Where(e => e.Id == id).Include(e => e.Pregunta).FirstOrDefault();
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

        public bool updateEncuesta(Encuestum encuesta)
        {
            try
            {
                Encuestum encuestaAntigua = _context.Encuesta.Where(e => e.Id == encuesta.Id).Include(e => e.Pregunta).FirstOrDefault();

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
