using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class FactorSubProyectoEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int PostulanteId { get; set; }
        public int TemaId { get; set; }
        public int? TipoEntidadParticipaId { get; set; }
        public int? BeneficioAmbientalId { get; set; }
        public int? TemaAmbientalId { get; set; }
        public int? BeneficioSocialId { get; set; }
        public int? EspecieId { get; set; }
        public int? EslabonId { get; set; }
        public int? NroBeneficiariosHombres { get; set; }
        public int? NroBeneficiariosMujeres { get; set; }
    }
}
