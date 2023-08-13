using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace BryanParkingLot.Models;

public class Cliente
{
    public Cliente( string nome, string sobrenome, string documento, string pais, Carro carro, string endereco)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Documento = documento;
        Pais = pais;
        Carro = carro;
        Endereco = endereco;
    }
    
    public Cliente()
    {
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Documento { get; set; }
    public string Pais { get; set; }
    public string Endereco { get; set; }
    public Carro Carro { get; set; }
}