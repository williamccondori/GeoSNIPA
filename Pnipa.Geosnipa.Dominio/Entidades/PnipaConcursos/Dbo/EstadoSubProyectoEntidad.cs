using Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido;

namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Dbo
{
    public class EstadoSubProyectoEntidad : EntidadAuditable
    {
        public int Id { get; set; }
        public int PostulanteId { get; set; }
        public int? CategoriaSubProyectoId { get; set; }
        public string? IndicadorSapel { get; set; }

        #region Constantes

        public const string NoEsSubProyectoSapel = "N";

        #endregion
    }
}
