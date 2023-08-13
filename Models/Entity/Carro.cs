using System.ComponentModel.DataAnnotations;

namespace BryanParkingLot.Models;

public class Carro
{
    public Carro( string marca, string modelo, string placa, bool estacionado, DateTime dataEntrada, DateTime? dataSaida)
    {
        Marca = marca;
        Modelo = modelo;
        Placa = placa;
        Estacionado = estacionado;
        DataEntrada = dataEntrada;
        DataSaida = dataSaida;
    }
    
    public Carro()
    {
    }
    
    public int Id { get; set; }
     public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public bool Estacionado { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime? DataSaida { get; set; }
    public int? ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}