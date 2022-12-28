namespace Pnipa.Geosnipa.Dominio.Modelos.Sapel;

public class SubProyectosModelo
{
    public int SubProyectoId { get; init; }
    public int FondoId { get; init; }
    public string DepartamentoId { get; init; } = default!;
    public string ProvinciaId { get; init; } = default!;
    public string DistritoId { get; init; } = default!;
    public string S1CodigoSubProyecto { get; init; } = default!;
    public string ConcursoNumero { get; init; } = default!;
    public string NombreConcurso { get; init; } = default!;
    public string Latitud { get; init; } = default!;
    public string Longitud { get; init; } = default!;
    public string S1Titulo { get; init; } = default!;
    public int OmrId { get; init; }
    public string CodigoContrato { get; init; } = default!;
    public string S1TmDetalleDescripcionTema { get; init; } = default!;
    public string S1TmDetalleDescripcionEslabon { get; init; } = default!;
    public int UsuarioId { get; init; }
    public string RazonSocial { get; init; } = default!;
    public string EstadoNombre { get; init; } = default!;
    public decimal AportePnipa { get; init; }
    public decimal TotalAporte { get; init; }
    public string TmDetDesctipcionCategoriaActividad { get; init; } = default!;
    public int S9CantidadAgentesProductivosHombres { get; init; }
    public int S9CantidadAgentesProductivosMujeres { get; init; }
    public int S9CantidadAgentesInnovacionHombres { get; init; }
    public int S9CantidadAgentesInnovacionMujeres { get; init; }

    public string Ventanilla => NombreConcurso.Replace("Ventanilla 01", "Primera ventanilla");
    public string Convocatoria => ConcursoNumero.Replace("CONC-2020-0001", "PNIPA 2020-2021");
    public string Usuario => UsuarioId.ToString();
}
