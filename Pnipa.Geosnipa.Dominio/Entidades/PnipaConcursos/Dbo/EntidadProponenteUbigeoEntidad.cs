namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class EntidadProponenteUbigeoEntidad
    {
        public int Id { get; set; }
        public int PostulanteId { get; set; }
        public string EstadoRegistro { get; set; } = default!;
    }
}
