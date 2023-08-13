import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {Cliente} from "../../Cliente";
import {ClientesService} from "../../clientes.service";

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  formulario: any;
  tituloFormulario: string = "Formulário de Clientes";

  constructor(private clienteService: ClientesService) {
  }

  ngOnInit() {
    this.tituloFormulario = "Formulário de Clientes";
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      sobrenome: new FormControl(null),
      documento: new FormControl(null),
      pais: new FormControl(null),
      endereco: new FormControl(null),
      carro: new FormControl(null),
      carroId: new FormControl(null)
    });
  }

  EnviarFormulario(): void {
    const cliente: Cliente = this.formulario.value;

    this.clienteService.createCliente(cliente).subscribe(resultado => {
      alert("Cliente cadastrado com sucesso!");
    });
  }
}
