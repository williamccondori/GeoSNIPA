using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pnipa.Geosnipa.Aplicacion.Caracteristicas.Ubicaciones.Queries.ObtenerTodasUbicaciones;

namespace Pnipa.Geosnipa.Api.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class UbicacionesController : ControllerBase
{
    private readonly IMediator _mediator;

    public UbicacionesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(
        StatusCodes.Status200OK,
        Type = typeof(IEnumerable<ObtenerTodasUbicacionesResponse>)
    )]
    public async Task<IActionResult> ObtenerTodasUbicaciones(
        [FromQuery] ObtenerTodasUbicacionesRequest request
    )
    {
        return Ok(await _mediator.Send(request));
    }
}
