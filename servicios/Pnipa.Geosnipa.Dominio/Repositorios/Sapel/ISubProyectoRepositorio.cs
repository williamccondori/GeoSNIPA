using Pnipa.Geosnipa.Dominio.Modelos;

namespace Pnipa.Geosnipa.Dominio.Repositorios.Sapel;

public interface ISubProyectoRepositorio
{
    Task<IEnumerable<ReporteParaGeoVisorModelo>> ObtenerReporteParaGeoVisor();
}