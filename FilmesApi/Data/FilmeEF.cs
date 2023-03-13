using FilmesApi.Interfaces;
using FilmesApi.Models;

namespace FilmesApi.Data;

public class FilmeEF: IFilmeRepository
{
    private FilmeContext _context;
    public FilmeEF(FilmeContext context)
    {
        _context = context;
    }

    public void Alterar(Filme obj)
    {       
        _context.SaveChanges();       
    }

    public Filme BuscarPorId(int id)
    {
        try
        {
            return _context.filmes.First(x => x.Id == id);
        }
        catch (Exception)
        {
            throw new Exception("Id não encontrado");
        }        
    }

    public IEnumerable<Filme> BuscarTodos()
    {
        return _context.filmes
            .Skip(0)
            .Take(10)
            .ToList();
    }

    public void Excluir(Filme obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public void Incluir(Filme obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }
}
