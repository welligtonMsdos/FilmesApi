using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public interface IFilmeService
    {
        IEnumerable<Filme> BuscarTodos();
        Filme BuscarPorId(int id);
        void Incluir(CreateFilmeDto obj);
        void Alterar(Filme obj);
        void Excluir(Filme obj);
    }
}
