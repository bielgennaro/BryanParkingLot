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