namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class VistaConvocatoriaEntidad
    {
        public int Id { get; set; }
        public int FondoId { get; set; }
        public string EstadoRegistro { get; set; } = default!;
    }
}
