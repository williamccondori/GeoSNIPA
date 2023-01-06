using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class PresupuestoEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int? PostulanteId { get; set; }
        public decimal? Total { get; set; }
        public decimal? MontoPrograma { get; set; }
        public decimal? MontoEntidades { get; set; }
        public decimal? PorcentajeEntidades { get; set; }
    }
}
