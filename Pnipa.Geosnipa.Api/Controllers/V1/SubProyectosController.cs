using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pnipa.Geosnipa.Aplicacion.Caracteristicas.SubProyectos.Queries.ObtenerReporteVisor;

namespace Pnipa.Geosnipa.Api.Controllers.V1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class SubProyectosController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubProyectosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ReporteVisor")]
    [ProducesResponseType(
        StatusCodes.Status200OK,
        Type = typeof(IEnumerable<ObtenerReporteVisorResponse>)
    )]
    public async Task<IActionResult> ObtenerReporteVisor(
        [FromQuery] ObtenerReporteVisorRequest request
    )
    {
        return Ok(await _mediator.Send(request));
    }
}
