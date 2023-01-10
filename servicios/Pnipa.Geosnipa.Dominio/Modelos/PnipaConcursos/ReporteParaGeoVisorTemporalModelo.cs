namespace Pnipa.Geosnipa.Dominio.Modelos.PnipaConcursos;

public class SubProyectoModelo
{
    public int PostulanteId { get; init; }
    public string? CodigoSubProyecto { get; init; }
    public string? Convocatoria { get; init; }
    public string? Ventanilla { get; init; }
    public string? InstitucionSuvencionadora { get; init; }
    public string? Ubigeo { get; init; }
    public string? Longitud { get; init; }
    public string? Latitud { get; init; }
    public string? SubSector { get; init; }
    public string? TipoFondo { get; init; }
    public string? Titulo { get; init; }
    public string? Departamento { get; init; }
    public string? Provincia { get; init; }
    public string? Distrito { get; init; }
    public string? Omr { get; init; }
    public decimal Bonificacion { get; init; }
    public string? Tema { get; init; }
    public string? Usuario { get; init; }
    public string? EntidadProponente { get; init; }
    public DateTime? FechaInicioReal { get; init; }
    public string? LinkImagenes { get; init; }
    public string? LinkImagenInicial { get; init; }
    public string? CodigoContrato { get; init; }
    public int? EspecieId { get; init; }
    public int? TipoEntidadParticipaId { get; init; }
    public int? BeneficioAmbientalId { get; init; }
    public int? TemaAmbientalId { get; init; }
    public int? BeneficioSocialId { get; init; }
    public int? EslabonId { get; init; }
    public int? NumeroBeneficiariosHombres { get; init; }
    public int? NumeroBeneficiariosMujeres { get; init; }
    public int? TotalBeneficiarios { get; init; }
    public string? Especie { get; init; }
}

public class CategoriaModelo
{
    public int PostulanteId { get; init; }
}

public class AdjudicacionModelo
{
    public int AdjudicacionId { get; init; }
}

public class VigenciaModelo
{
    public int PostulanteId { get; init; }
    public string? CodigoEnvioProyecto { get; init; }
    public bool VigenteOk { get; init; }
}

public class AportesModelo
{
    public int PostulanteId { get; init; }
    public decimal? TotalSubProyecto { get; init; }
    public decimal? AportePnipa { get; init; }
    public decimal? AporteEntidadProponente { get; init; }
    public decimal? AporteEntidadAsociada { get; init; }
    public decimal? AporteEntidadColaboradora { get; init; }
}

public class DesembolsoModelo
{
    public int PostulanteId { get; init; }
    public string? Hito { get; init; }
    public decimal? DesembolsoPnipa { get; init; }
}

public class MontoPasoCriticoModelo
{
    public int PasoCriticoId { get; init; }
    public decimal Monto { get; init; }
}