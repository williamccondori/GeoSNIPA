namespace Pnipa.Geosnipa.Dominio.Repositorios;

public interface ISapelLecturaRepositorio<T> where T : class
{
    Task<IEnumerable<T>> ObtenerTodos();
}