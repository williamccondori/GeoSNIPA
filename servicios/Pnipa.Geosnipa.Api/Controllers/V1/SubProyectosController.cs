using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pnipa.Geosnipa.Aplicacion.Caracteristicas.SubProyectos.Commands.GuardarReporteParaGeoVisor;
using Pnipa.Geosnipa.Aplicacion.Caracteristicas.SubProyectos.Queries.ObtenerReporteParaGeoVisor;

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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ObtenerReporteParaGeoVisorResponse>))]
    public async Task<IActionResult> ObtenerReporteVisor([FromQuery] ObtenerReporteParaGeoVisorRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost("reportes-geovisor")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GuardarReporteParaGeoVisorResponse))]
    public async Task<IActionResult> GuardarReporteParaGeoVisor([FromQuery] GuardarReporteParaGeoVisorRequest request)
    {
        return Ok(await _mediator.Send(request));
    }
}