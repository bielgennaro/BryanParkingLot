import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {HomeComponent} from './home/home.component';
import {CounterComponent} from './counter/counter.component';
import {FetchDataComponent} from './fetch-data/fetch-data.component';
import {ClientesService} from "./clientes.service";
import {CommonModule} from "@angular/common";
import {CarrosService} from "./carros.service";
import {ClientesComponent} from "./components/clientes/clientes.component";
import {CarrosComponent} from "./components/carros/carros.component";

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    CarrosComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'clientes', component: ClientesComponent},
      {path: 'carros', component: CarrosComponent},
      {path: 'counter', component: CounterComponent},
      {path: 'fetch-data', component: FetchDataComponent},
    ])
  ],
  providers: [HttpClientModule, ClientesService, CarrosService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
