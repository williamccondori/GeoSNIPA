using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pnipa.Geosnipa.Dominio.Modelos.PnipaConcursos
{
    public class SubProyectosModelo
    {
        public int PostulanteId { get; set; }
        public int ProyectoId { get; set; }
        public string CodigoEnvioProyecto { get; set; } = default!;
        public string Ventanilla { get; set; } = default!;
        public string EntidadProponente { get; set; } = default!;
    }
}
