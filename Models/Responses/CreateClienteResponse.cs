using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace BryanParkingLot.Models;

public class CreateClientResponse
{
    public string Documento { get; set; }
    public string Pais { get; set; }
    public CreateCarroRequest Carro { get; set; }
}