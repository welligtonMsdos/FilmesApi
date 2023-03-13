using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Interfaces;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private IFilmeService _filmeService;
    private IMapper _mapper;

    public FilmeController(IFilmeService filmeService, IMapper mapper)
    {
        _filmeService = filmeService;
        _mapper = mapper;
    }

    /// <summary>
    /// Adciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso o inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult InserirFilme([FromBody] CreateFilmeDto filmeDto)
    {
        _filmeService.Incluir(filmeDto);

        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filmeDto.Id }, filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        _filmeService.Alterar(id,filmeDto);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _filmeService.BuscarPorId(id);

        var filmePatch = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmePatch, ModelState);

        if (!TryValidateModel(ModelState)) return ValidationProblem(ModelState);

        _mapper.Map(filmePatch, filme);

        _filmeService.AlterarByPatch(filme);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        _filmeService.Excluir(id);

        return NoContent();
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes()
    {
        return _mapper.Map<List<ReadFilmeDto>>(_filmeService.BuscarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _filmeService.BuscarPorId(id);       

        if (filme == null) return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }
}
