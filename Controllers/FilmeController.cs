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
    public async Task<List<Filme>> Get() {
        return await _context.Filmes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Filme>> Get(int id) {
        var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);
        return Ok(filme);
    }

    [HttpPost]
    public async Task<ActionResult<Filme>> Post([FromBody] Filme filme) {
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        return Ok(filme);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Filme>> Put(int id, [FromBody] Filme filme) {
        filme.Id = id;
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();
        return Ok(filme);
    }    

    [HttpDelete("{id}")]
    public async Task<ActionResult<Filme>> Delete(int id) {
        var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);
        _context.Filmes.Remove(filme);
        await _context.SaveChangesAsync();

        return Ok(filme);
    }
}