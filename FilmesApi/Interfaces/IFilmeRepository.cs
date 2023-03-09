using FilmesApi.Models;

namespace FilmesApi.Interfaces;

public interface IFilmeRepository: IQuery<Filme>, ICommand<Filme>
{
}
