using MediatR;

namespace Pnipa.Geosnipa.Aplicacion.Caracteristicas.SubProyectos.Queries.ObtenerReporteVisor;

public class ObtenerReporteParaGeoVisorRequest
    : IRequest<IEnumerable<ObtenerReporteParaGeoVisorResponse>> { }
