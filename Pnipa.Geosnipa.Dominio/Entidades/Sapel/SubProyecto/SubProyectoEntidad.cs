using Pnipa.Geosnipa.Dominio.Entidades.Sapel.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.Sapel.SubProyecto;

public class SubProyectoEntidad : EntidadAuditableSapel
{
    public int SubProyectoId { get; set; }
    public int EntidadId { get; set; }
    public int UsuarioId { get; set; }
    public int ConcursoFondoId { get; set; }
    public string? S1Titulo { get; set; }
    public string? S1TmDetalleDescripcionEslabon { get; set; }
    public string? S1TmDetalleDescripcionTema { get; set; }
    public int EstadoId { get; set; }
    public string? EstadoNombre { get; set; }
    public string? S1CodigoSubProyecto { get; set; }
    public int S9CantidadAgentesProductivosHombres { get; set; }
    public int S9CantidadAgentesProductivosMujeres { get; set; }
    public int S9CantidadAgentesInnovacionHombres { get; set; }
    public int S9CantidadAgentesInnovacionMujeres { get; set; }
    public int SubProyectoIdPadre { get; set; }
    public decimal TotalAporte { get; set; }
    public decimal AportePnipa { get; set; }
}