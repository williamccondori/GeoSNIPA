using MediatR;
using Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;
using Pnipa.Geosnipa.Dominio.Repositorios;

namespace Pnipa.Geosnipa.Aplicacion.Caracteristicas.Ubicaciones.Queries.ObtenerTodasUbicaciones;

public class
    // ReSharper disable once UnusedType.Global
    ObtenerTodasUbicacionesHandler : IRequestHandler<ObtenerTodasUbicacionesRequest,
        IEnumerable<ObtenerTodasUbicacionesResponse>>
{
    private readonly ISapelLecturaRepositorio<S1UbicacionEntidad> _sapelLecturaRepositorio;

    public ObtenerTodasUbicacionesHandler(ISapelLecturaRepositorio<S1UbicacionEntidad> sapelLecturaRepositorio)
    {
        _sapelLecturaRepositorio = sapelLecturaRepositorio;
    }

    public async Task<IEnumerable<ObtenerTodasUbicacionesResponse>> Handle(ObtenerTodasUbicacionesRequest request,
        CancellationToken cancellationToken)
    {
        var s1Ubicaciones = await _sapelLecturaRepositorio.ObtenerTodos();

        return s1Ubicaciones.Select(x => new ObtenerTodasUbicacionesResponse
        {
            UbicacionId = x.UbicacionId,
            NombreCompleto = x.NombreCompleto
        });
    }
}