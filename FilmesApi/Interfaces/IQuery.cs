namespace FilmesApi.Interfaces;

public interface IQuery<T>
{
    IEnumerable<T> BuscarTodos();
    T BuscarPorId(int id);
}
