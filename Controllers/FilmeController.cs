using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase {
    private readonly ApplicationDbContext _context;
    public FilmeController(ApplicationDbContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<List<FilmeOutputGetAllDTO>> Get() {
        var filmes = await _context.Filmes.ToListAsync();

        var outputDTOList = new List<FilmeOutputGetAllDTO>();

        foreach (Filme filme in filmes) {
            outputDTOList.Add(new FilmeOutputGetAllDTO(filme.Id, filme.Titulo, filme.Ano, filme.Genero));
        }

        return outputDTOList;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FilmeOutputGetByIdDTO>> Get(int id) {
        var filme = await _context.Filmes.Include(filme => filme.Diretor).FirstOrDefaultAsync(filme => filme.Id == id);

        var outputDTO = new FilmeOutputGetByIdDTO(filme.Id, filme.Titulo, filme.Ano, filme.Genero, filme.Diretor.Nome);
        return Ok(outputDTO);
    }

    [HttpPost]
    public async Task<ActionResult<FilmeOutputPostDTO>> Post([FromBody] FilmeInputPostDTO inputDTO) {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == inputDTO.DiretorId);

        if (diretor == null) {
            return NotFound("Diretor informado não encontrado");
        }
    
        var filme = new Filme(inputDTO.Titulo, inputDTO.Ano, inputDTO.Genero, inputDTO.DiretorId);
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        var outputDTO = new FilmeOutputPostDTO(filme.Id, filme.Titulo, filme.Ano, filme.Genero);
        return Ok(outputDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FilmeOutputPutDTO>> Put(int id, [FromBody] FilmeInputPutDTO inputDTO) {
        var filme = new Filme(inputDTO.Titulo, inputDTO.Ano, inputDTO.Genero, id);
        filme.Id = id;
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();

        var outputDTO = new FilmeOutputPutDTO(filme.Id, filme.Titulo, filme.Ano, filme.Genero);
        return Ok(outputDTO);
    }    

    [HttpDelete("{id}")]
    public async Task<ActionResult<Filme>> Delete(int id) {
        var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);
        _context.Filmes.Remove(filme);
        await _context.SaveChangesAsync();

        return Ok(filme);
    }
}