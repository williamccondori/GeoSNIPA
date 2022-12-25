using Pnipa.Geosnipa.Dominio.Modelos;

namespace Pnipa.Geosnipa.Dominio.Repositorios;

public interface ISubProyectoRepositorio
{
    Task<IEnumerable<ReporteVisorModelo>> ObtenerReporteParaGeoVisor();
}