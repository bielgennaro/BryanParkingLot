using BryanParkingLot.Data;
using BryanParkingLot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BryanParkingLot.Controllers;

[ApiController]
[Route("api/carros")]
public class CarrosController : ControllerBase
{
    private readonly BryanParkingLotContext _context;

    public CarrosController(BryanParkingLotContext _context)
    {
        this._context = _context;
    }
    
    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<Carro>>> GetCarros()
    {
        return await _context.Carros.ToListAsync();
    }
    
    [HttpGet("list/{id:int}")]
    public async Task<ActionResult<Carro>> GetCarro(int id)
    {
        var carro = await _context.Carros.FindAsync(id);

        if (carro == null)
        {
            return NotFound();
        }

        return carro;
    }
    
    [HttpPost("create")]
    public async Task<ActionResult<Carro>> PostCarro(Carro carro)
    {
        await _context.Carros.AddAsync(carro);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCarro", new { id = carro.Id }, carro);
    }
    
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> PutCarro(int id, Carro carro)
    {
        if (id != carro.Id)
        {
            return BadRequest();
        }

        _context.Entry(carro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CarroExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCarro(int id)
    {
        var carro = await _context.Carros.FindAsync(id);
        if (carro == null)
        {
            return NotFound();
        }

        _context.Carros.Remove(carro);
        await _context.SaveChangesAsync();

        return Ok();
    }
    
    private bool CarroExists(int id)
    {
        return _context.Carros.Any(e => e.Id == id);
    }
}
