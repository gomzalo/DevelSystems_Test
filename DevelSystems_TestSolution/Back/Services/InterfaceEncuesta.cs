using Back.Models.DB;

namespace Back.Services
{
    public interface InterfaceEncuesta
    {

        Encuestum getEncuesta(int id);

        IEnumerable<Encuestum> getEncuestas();

        string addEncuesta(Encuestum encuesta);

        bool addRespuesta(Respuestum respuesta);

        bool updateEncuesta(Encuestum encuesta);

        bool delEncuesta(int id);

    }
}
