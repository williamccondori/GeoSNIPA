namespace Pnipa.Geosnipa.Dominio.Modelos.PnipaConcursos
{
    public class SubProyectoModelo
    {
        public int PostulanteId { get; set; }
        public int ProyectoId { get; set; }
        public string? CodigoSubProyecto { get; set; }
        public string? Convocatoria { get; set; }
        public string? Ventanilla { get; set; }
        public string? InstitucionSuvencionadora { get; set; }
        public string? Ubigeo { get; set; }
        public string? Longitud { get; set; }
        public string? Latitud { get; set; }
        public string? SubSector { get; set; }
        public string? TipoFondo { get; set; }
        public string? Titulo { get; set; }
        public string? Departamento { get; set; }
        public string? Provincia { get; set; }
        public string? Distrito { get; set; }
        public string? Omr { get; set; }
        public decimal Bonificacion { get; set; }
        public string? Tema { get; set; }
        public string? Usuario { get; set; }
        public string? EntidadProponente { get; set; }
        public DateTime? FechaInicioReal { get; set; }
        public string? LinkImagenes { get; set; }
        public string? LinkImagenInicial { get; set; }
        public string? CodigoContrato { get; set; }
        public string? Codigo { get; set; }
        public int? EspecieId { get; set; }
        public int? TipoEntidadParticipaId { get; set; }
        public int? BeneficioAmbientalId { get; set; }
        public int? TemaAmbientalId { get; set; }
        public int? BeneficioSocialId { get; set; }
        public int? EslabonId { get; set; }
        public int? NumeroBeneficiariosHombres { get; set; }
        public int? NumeroBeneficiariosMujeres { get; set; }
        public int? TotalBeneficiarios { get; set; }
        public string? IdEmblematico { get; set; }
        public string? LinkFicha { get; set; }
        public string? HambreCero { get; set; }
        public string? Especie { get; set; }
    }

    public class CategoriaModelo
    {
        public int CategoriaSubProyectoId { get; set; }
        public int PostulanteId { get; set; }
    }

    public class AdjudicacionModelo
    {
        public int PostulanteId { get; set; }
        public int AdjudicacionId { get; set; }
    }

    public class VigenciaModelo
    {
        public int PostulanteId { get; set; }
        public string? CodigoEnvioProyecto { get; set; }
        public bool? Vigente { get; set; }
        public int? EstadoInforme { get; set; }
        public bool VigenteOk { get; set; }
    }

    public class AportesModelo
    {
        public int PostulanteId { get; set; }
        public decimal? TotalSubProyecto { get; set; }
        public decimal? AportePnipa { get; set; }
        public decimal? AporteEntidadProponente { get; set; }
        public decimal? AporteEntidadAsociada { get; set; }
        public decimal? AporteEntidadColaboradora { get; set; }
    }

    public class DesembolsoModelo
    {
        public int PostulanteId { get; set; }
        public string? Hito { get; set; }
        public decimal? DesembolsoPnipa { get; set; }
    }

    public class MontoPasoCriticoModelo
    {
        public int PasoCriticoId { get; set; }
        public decimal Monto { get; set; }
    }
}
