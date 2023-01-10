namespace Pnipa.Geosnipa.Dominio.Modelos.Sapel;

public class SubProyectoModelo
{
    public int SubProyectoId { get; init; }
    public int FondoId { get; init; }
    public string? DepartamentoId { get; init; }
    public string? ProvinciaId { get; init; }
    public string? DistritoId { get; init; }
    public string? S1CodigoSubProyecto { get; init; }
    public string? ConcursoNumero { get; init; }
    public string? NombreConcurso { get; init; }
    public string? Latitud { get; init; }
    public string? Longitud { get; init; }
    public string? S1Titulo { get; init; }
    public int OmrId { get; init; }
    public string? CodigoContrato { get; init; }
    public string? S1TmDetalleDescripcionTema { get; init; }
    public string? S1TmDetalleDescripcionEslabon { get; init; }
    public int UsuarioId { get; init; }
    public string? RazonSocial { get; init; }
    public string? EstadoNombre { get; init; }
    public decimal AportePnipa { get; init; }
    public decimal TotalAporte { get; init; }
    public string? TmDetDesctipcionCategoriaActividad { get; init; }
    public int S9CantidadAgentesProductivosHombres { get; init; }
    public int S9CantidadAgentesProductivosMujeres { get; init; }
    public int S9CantidadAgentesInnovacionHombres { get; init; }
    public int S9CantidadAgentesInnovacionMujeres { get; init; }

    public string? Ventanilla => NombreConcurso?.Replace("Ventanilla 01", "Primera ventanilla");
    public string? Convocatoria => ConcursoNumero?.Replace("CONC-2020-0001", "PNIPA 2020-2021");
}

public class AporteModelo
{
    public int SubProyectoId { get; init; }
    public string? Entidad { get; init; }
    public decimal MontoAporte { get; init; }
}

public class EspecieModelo
{
    public int SubProyectoId { get; init; }
    public string? Nombre { get; init; }
}