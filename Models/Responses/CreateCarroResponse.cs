using System.ComponentModel.DataAnnotations;

namespace BryanParkingLot.Models;

public class CreateCarroResponse
{
    public string Placa { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime? DataSaida { get; set; }
}