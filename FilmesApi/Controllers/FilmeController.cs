using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private IFilmeService _filmeService;

    public FilmeController(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpPost]
    public IActionResult InserirFilme([FromBody] CreateFilmeDto filmeDto)
    {
        _filmeService.Incluir(filmeDto);

        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filmeDto.Id }, filmeDto);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes()
    {
        return _filmeService.BuscarTodos();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _filmeService.BuscarPorId(id);

        if (filme == null) return NotFound();

        return Ok(filme);
    }
}
