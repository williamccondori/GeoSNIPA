namespace Pnipa.Geosnipa.Dominio.Modelos.PnipaConcursos
{
    public class SubProyectosModelo
    {
        public int PostulanteId { get; set; }
        public int ProyectoId { get; set; }
        public string CodigoSubProyecto { get; set; } = default!;
        public string Convocatoria { get; set; } = default!;
        public string Ventanilla { get; set; } = default!;
        public string InstitucionSuvencionadora { get; set; } = default!;
        public string Ubigeo { get; set; } = default!;
        public string Longitud { get; set; } = default!;
        public string Latitud { get; set; } = default!;
        public string SubSector { get; set; } = default!;
        public string TipoFondo { get; set; } = default!;
        public string TituloSubProyecto { get; set; } = default!;
        public string Departamento { get; set; } = default!;
        public string Provincia { get; set; } = default!;
        public string Distrito { get; set; } = default!;
        public string Omr { get; set; } = default!;
        public decimal Bonificacion { get; set; }
        public string Tema { get; set; } = default!;
        public string Usuario { get; set; } = default!;
        public string EntidadProponente { get; set; } = default!;
        public string EstadoEjecucion { get; set; } = default!;
        public string LinkImagenInicial { get; set; } = default!;
        public string LinkImagenes { get; set; } = default!;
        public string NumeroContrato { get; set; } = default!;
        public string Codigo { get; set; } = default!;
        public string Especie { get; set; } = default!;
        public bool VigenteOk { get; set; }
        public string TipoEntidadParticipa { get; set; } = default!;
        public string BeneficioAmbiental { get; set; } = default!;
        public string TemaAmbiental { get; set; } = default!;
        public string BeneficioSocial { get; set; } = default!;
        public string Eslabon { get; set; } = default!;
        public int? NumeroBeneficiariosMujeres { get; set; }
        public int? NumeroBeneficiariosHombres { get; set; }
        public int? TotalBeneficiarios { get; set; }
        public string IdEmblematico { get; set; } = default!;
        public string LinkFicha { get; set; } = default!;
        public string? HambreCero { get; set; }
    }
}
