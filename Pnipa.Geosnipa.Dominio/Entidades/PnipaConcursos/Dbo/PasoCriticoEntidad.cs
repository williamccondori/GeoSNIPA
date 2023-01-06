using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class PasoCriticoEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int? ProyectoId { get; set; }
        public short? MesInicio { get; set; }
        public short? MesFin { get; set; }
        public short? Numero { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public int? OldId { get; set; }
    }
}
