using BryanParkingLot.Data;
using BryanParkingLot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BryanParkingLot.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private readonly BryanParkingLotContext _context;

    public ClientesController(BryanParkingLotContext _context)
    {
        this._context = _context;
    }

    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpGet("list/{id:int}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Cliente>> PostCliente(CreateClientRequest clienteRequest)
    {
        var carro = new Carro(clienteRequest.Carro.Marca, clienteRequest.Carro.Modelo, clienteRequest.Carro.Placa,
            clienteRequest.Carro.Estacionado, clienteRequest.Carro.DataEntrada, clienteRequest.Carro.DataSaida);

        var cliente = new Cliente(clienteRequest.Nome, clienteRequest.Sobrenome, clienteRequest.Documento,
            clienteRequest.Pais, carro, clienteRequest.Endereco);

        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();

        return Ok(new { clienteId = cliente.Id });
    }

    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> UpdateCliente(int id, CreateClientRequest clienteRequest)
    {
        var existingCliente = await _context.Clientes.FindAsync(id);

        if (existingCliente == null)
        {
            return NotFound();
        }

        var updatedCarro = new Carro(
            clienteRequest.Carro.Marca,
            clienteRequest.Carro.Modelo,
            clienteRequest.Carro.Placa,
            clienteRequest.Carro.Estacionado,
            clienteRequest.Carro.DataEntrada,
            clienteRequest.Carro.DataSaida
        );

        existingCliente.Nome = clienteRequest.Nome;
        existingCliente.Sobrenome = clienteRequest.Sobrenome;
        existingCliente.Documento = clienteRequest.Documento;
        existingCliente.Pais = clienteRequest.Pais;
        existingCliente.Carro = updatedCarro;
        existingCliente.Endereco = clienteRequest.Endereco;

        try
        {
            _context.Update(existingCliente);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return Ok();
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);

        try
        {
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Ocorreu um erro ao excluir o cliente: {ex.Message}");
        }
    }

    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(e => e.Id == id);
    }
}