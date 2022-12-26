namespace Pnipa.Geosnipa.Dominio.Modelos.PnipaConcursos
{
    public class SubProyectosModelo
    {
        public int PostulanteId { get; set; }
        public int ProyectoId { get; set; }
        public string CodigoEnvioProyecto { get; set; } = default!;
        public int Ventanilla { get; set; }
        public string EntidadProponente { get; set; } = default!;
    }
}
