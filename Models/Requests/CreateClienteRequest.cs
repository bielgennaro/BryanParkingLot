using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace BryanParkingLot.Models;

public class CreateClientRequest
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Endereco { get; set; }
    public string Documento { get; set; }
    public string Pais { get; set; }
    public CreateCarroRequest Carro { get; set; }
}