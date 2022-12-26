using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class PostulanteEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int EtapaId { get; set; }
        public string? CodigoEnvioProyecto { get; set; }
        public int Ventanilla { get; set; }
        public int UsuarioId { get; set; }
        public int ConvocatoriaId { get; set; }
    }
}
