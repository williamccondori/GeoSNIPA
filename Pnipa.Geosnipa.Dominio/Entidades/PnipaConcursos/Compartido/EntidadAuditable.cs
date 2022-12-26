namespace Pnipa.Geosnipa.Dominio.Entidades.PnipaConcursos.Compartido
{
    public abstract class EntidadAuditable
    {
        public string EstadoRegistro { get; set; } = default!;
        public int UsuarioIdRegistro { get; set; }
        public int UsuarioIdModifico { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }

        #region Constantes

        public const string EstadoRegistroActivo = "1";

        #endregion
    }
}
