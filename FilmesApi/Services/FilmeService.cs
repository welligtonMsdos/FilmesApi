using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Interfaces;
using FilmesApi.Models;

namespace FilmesApi.Services
{
    public class FilmeService : IFilmeService
    {
        private IFilmeRepository _filmeRepository;
        private IMapper _mapper;
        public FilmeService(IFilmeRepository filmeRepository, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public void Alterar(Filme obj)
        {
            _filmeRepository.Alterar(obj);
        }

        public Filme BuscarPorId(int id)
        {
            return _filmeRepository.BuscarPorId(id);
        }

        public IEnumerable<Filme> BuscarTodos()
        {
            return _filmeRepository.BuscarTodos();
        }

        public void Excluir(Filme obj)
        {
            _filmeRepository.Excluir(obj);
        }

        public void Incluir(CreateFilmeDto obj)
        {
            var filme = _mapper.Map<Filme>(obj);

            _filmeRepository.Incluir(filme);

            obj.Id = filme.Id;
        }
    }
}
