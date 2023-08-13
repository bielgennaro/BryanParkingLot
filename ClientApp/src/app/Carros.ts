import {Cliente} from "./Cliente";

export class Carros {
  marca: string;
  modelo: string;
  estacionado: boolean;
  dataEntrada: Date;
  dataSaida: Date;
  cliente: Cliente;
  placa:string;
  clienteId: number;

  constructor() {
    this.clienteId = 0;
    this.marca = '';
    this.modelo = '';
    this.placa = '';
    this.estacionado = false;
    this.dataEntrada = new Date();
    this.dataSaida = new Date();
    this.cliente = new Cliente();
  }
}
