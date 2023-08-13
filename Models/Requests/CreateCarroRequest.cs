using System.ComponentModel.DataAnnotations;

namespace BryanParkingLot.Models;

public class CreateCarroRequest
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public bool Estacionado { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime? DataSaida { get; set; }
}