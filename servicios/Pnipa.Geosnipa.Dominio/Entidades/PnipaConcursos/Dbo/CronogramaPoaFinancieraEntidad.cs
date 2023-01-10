using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo;

public class CronogramaPoaFinancieraEntidad : EntidadAuditable
{
    public int Id { get; set; }
    public int? PoaId { get; set; }
    public int? ProyectoId { get; set; }
    public int? Mes { get; set; }
    public decimal? Meta { get; set; }
    public decimal? Monto { get; set; }
    public int? OldId { get; set; }
}