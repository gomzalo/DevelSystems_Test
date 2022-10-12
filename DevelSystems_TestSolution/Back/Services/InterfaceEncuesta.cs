using Back.Models;

namespace Back.Services
{
    public interface InterfaceEncuesta
    {
        IEnumerable<Respuestum> getRespuestas(string nombre);

        Encuestum getEncuesta(string nombre);

        IEnumerable<Encuestum> getEncuestas();

        string addEncuesta(Encuestum encuesta);

        bool addRespuesta(Respuestum respuesta);

        bool updateEncuesta(Encuestum encuesta);

        bool delEncuesta(string nombre);

    }
}
