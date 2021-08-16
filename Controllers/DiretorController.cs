using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase {
    private readonly ApplicationDbContext _context;
    public DiretorController(ApplicationDbContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<List<DiretorOutputGetAllDTO>> Get() {
        var diretores = await _context.Diretores.ToListAsync();

        var outputDTOList = new List<DiretorOutputGetAllDTO>();

        foreach (Diretor diretor in diretores) {
            outputDTOList.Add(new DiretorOutputGetAllDTO(diretor.Id, diretor.Nome));
        }

        return outputDTOList;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DiretorOutputGetByIdDTO>> Get(int id) {
       var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);

       var outputDTO = new DiretorOutputGetByIdDTO(diretor.Id, diretor.Nome);
       return Ok(outputDTO);
    }


    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post(DiretorInputPostDTO diretorInputDTO) {
        var diretor = new Diretor(diretorInputDTO.Nome);
       _context.Diretores.Add(diretor);
       await _context.SaveChangesAsync();

       var diretorOutputDTO = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
       return Ok(diretorOutputDTO); 
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DiretorOutputPutDTO>> Put(int id, [FromBody] DiretorInputPutDTO diretorInputPutDTO) {
        var diretor = new Diretor(diretorInputPutDTO.Nome);
        diretor.Id = id;
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        var DiretorOutputPutDTO = new DiretorOutputPutDTO(diretor.Id, diretor.Nome);
        return Ok(DiretorOutputPutDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        _context.Remove(diretor);
        await _context.SaveChangesAsync();
        return Ok();
    }
}