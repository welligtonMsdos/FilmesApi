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

        public void Alterar(int id, UpdateFilmeDto obj)
        {
            var filme = _filmeRepository.BuscarPorId(id);

            _mapper.Map(obj, filme);

            filme.Id = id;

            _filmeRepository.Alterar(filme);
        }

        public void AlterarByPatch(Filme obj)
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

        public void Excluir(int id)
        {
            var filme = _filmeRepository.BuscarPorId(id);

            _filmeRepository.Excluir(filme);
        }

        public void Incluir(CreateFilmeDto obj)
        {
            var filme = _mapper.Map<Filme>(obj);

            _filmeRepository.Incluir(filme);

            obj.Id = filme.Id;
        }
    }
}
