using Pnipa.Geosnipa.Dominio.Modelos;

namespace Pnipa.Geosnipa.Dominio.Repositorios;

public interface ISapelSubProyectoRepositorio
{
    Task<IEnumerable<ReporteVisorModelo>> ObtenerReporteParaGeoVisor();
}
