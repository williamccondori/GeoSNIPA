namespace Pnipa.Geosnipa.Dominio.Modelos;

public class ReporteVisorModelo
{
    public string S1CodigoSubProyecto { get; init; } = default!;
    public string CodigoSubProyecto { get; init; } = default!;
    public string Convocatoria { get; init; } = default!;
    public string Ventanilla { get; init; } = default!;
    public string InstitucionSuvencionadora { get; init; } = default!;
    public string Ubigeo { get; init; } = default!;
    public string Longitud { get; init; } = default!;
    public string Latitud { get; init; } = default!;
    public string SubSector { get; init; } = default!;
    public string TipoFondo { get; init; } = default!;
    public string TituloSubproyecto { get; init; } = default!;
    public string Departamento { get; init; } = default!;
    public string Provincia { get; init; } = default!;
    public string Distrito { get; init; } = default!;
    public string Omr { get; init; } = default!;
    public decimal Bonificacion { get; init; }
    public string Tema { get; init; } = default!;
    public string EslabonCadena { get; init; } = default!;
    public string Especies { get; init; } = default!;
    public string Usuario { get; init; } = default!;
    public string EntidadProponente { get; init; } = default!;
    public string EstadoEjecucion { get; init; } = default!;
    public string LinkImagenInicial { get; init; } = default!;
    public string LinkImagenes { get; init; } = default!;
    public string CodigoContrato { get; init; } = default!;
    public decimal AporteEntidadAsociada { get; init; }
    public decimal AporteEntidadColaboradora { get; init; }
    public decimal AporteEntidadProponente { get; init; }
    public decimal AportePnipa { get; init; }
    public decimal TotalSubProyecto { get; init; }
    public string Hito { get; init; } = default!;
    public decimal DesenbolsoPnipa { get; init; }
    public string TipoEntidadParticipa { get; init; } = default!;
    public string BeneficioAmbiental { get; init; } = default!;
    public string TemaAmbiental { get; init; } = default!;
    public string BeneficioSocial { get; init; } = default!;
    public int NroBeneficiariosMujeres { get; init; }
    public int NroBeneficiariosHombres { get; init; }
    public int TotalBeneficiarios { get; init; }
    public string SubProyectoEmblematico { get; init; } = default!;
    public string LinkFicha { get; init; } = default!;
    public string HambreCero { get; init; } = default!;

    #region Contstantes
    public const string InstitucionSubencionadoraPnipa = "PNIPA";
    public const string PrimerHito = "H1";
    public const string NoEsSubProyectoEmblematico = "N";
    public const string NoEsSubProyectoHambreCero = "N";
    #endregion
}
