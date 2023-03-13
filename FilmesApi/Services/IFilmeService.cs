using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Services
{
    public interface IFilmeService
    {
        IEnumerable<Filme> BuscarTodos();
        Filme BuscarPorId(int id);
        void Incluir(CreateFilmeDto obj);
        void Alterar(int id, UpdateFilmeDto obj);
        void AlterarByPatch(Filme obj);            
        void Excluir(int id);
    }
}
