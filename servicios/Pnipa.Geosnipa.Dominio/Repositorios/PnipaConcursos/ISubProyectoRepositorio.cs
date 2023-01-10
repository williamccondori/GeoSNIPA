using Pnipa.Geosnipa.Dominio.Modelos;

namespace Pnipa.Geosnipa.Dominio.Repositorios.PnipaConcursos;

public interface ISubProyectoRepositorio
{
    Task<IEnumerable<ReporteParaGeoVisorModelo>> ObtenerReporteParaGeoVisor();
}