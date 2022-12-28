using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class ProductoPlanNegocioEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int PlanNegocioId { get; set; }
        public string? Nombre { get; set; }
    }
}
