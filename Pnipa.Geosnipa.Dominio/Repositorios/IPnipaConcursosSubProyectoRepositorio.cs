using Pnipa.Geosnipa.Dominio.Modelos;

namespace Pnipa.Geosnipa.Dominio.Repositorios
{
    public interface IPnipaConcursosSubProyectoRepositorio
    {
        Task<IEnumerable<ReporteVisorModelo>> ObtenerReporteParaGeoVisor();
    }
}
