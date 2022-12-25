namespace Pnipa.Geosnipa.Dominio.Repositorios;

public interface ILecturaRepositorio<T> where T : class
{
    Task<IEnumerable<T>> ObtenerTodos();
}