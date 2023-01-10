using Pnipa.Geosnipa.Dominio.Entidades.Geosnipa;

namespace Pnipa.Geosnipa.Dominio.Repositorios.Geosnipa;

public interface ISubProyectoRepositorio
{
    Task<IEnumerable<SubProyectoEntidad>> ObtenerTodos();
    Task CrearVarios(IEnumerable<SubProyectoEntidad> subProyectos);
    Task EliminarTodos();
}