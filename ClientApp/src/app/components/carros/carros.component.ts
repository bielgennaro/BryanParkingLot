import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {Carros} from "../../Carros";
import {CarrosService} from "../../carros.service";
import {Cliente} from "../../Cliente";

@Component({
  selector: 'app-carros',
  templateUrl: './carros.component.html',
  styleUrls: ['./carros.component.css']
})
export class CarrosComponent implements OnInit {

  formulario: any;
  tituloFormulario: string = "Formulario de Carros";
  carros: Carros[] = [];

  constructor(private carrosService: CarrosService) {
  }

  ngOnInit(): void {
    this.carrosService.getCarros().subscribe(resultado => {
      this.carros = resultado;
    })

    this.formulario = new FormGroup({
      marca: new FormControl(null),
      modelo: new FormControl(null),
      estacionado: new FormControl(null),
      dataEntrada: new FormControl(null),
      dataSaida: new FormControl(null),
      cliente: new FormControl(null)
    })
  }

  EnviarFormulario(): void {
    const cliente: Cliente = this.formulario.value;

    this.carrosService.getCarros().subscribe(resultado => {
      alert("Cliente com sucesso!");
    });
  }
}
