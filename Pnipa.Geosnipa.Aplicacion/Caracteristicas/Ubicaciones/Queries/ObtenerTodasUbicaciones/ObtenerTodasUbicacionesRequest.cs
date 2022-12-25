using MediatR;

namespace Pnipa.Geosnipa.Aplicacion.Caracteristicas.Ubicaciones.Queries.ObtenerTodasUbicaciones;

public class ObtenerTodasUbicacionesRequest : IRequest<IEnumerable<ObtenerTodasUbicacionesResponse>>
{
}