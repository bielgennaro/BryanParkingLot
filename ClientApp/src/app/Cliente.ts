import {Carros} from "./Carros";

export class Cliente {
  id: number;
  nome: string;
  sobrenome: string;
  documento: string = '';
  pais: string;
  endereco: string;
  carro: Carros;
  carroId: number;

  constructor() {
    this.id = 0;
    this.nome = '';
    this.sobrenome = '';
    this.pais = '';
    this.endereco = '';
    this.carro = new Carros();
    this.carroId = 0;
  }
}

