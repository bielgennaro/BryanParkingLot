import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Cliente} from "./Cliente";

const HttpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  url: string = "https://localhost:7137/api/clientes";

  constructor(private http: HttpClient) {
  }

  getClientes(cliente: Cliente): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${this.url}/list`);
  }

  getClienteById(id: number): Observable<Cliente> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<Cliente>(apiUrl);
  }

  createCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(`${this.url}/create`, cliente, HttpOptions);
  }

  updateCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.put<Cliente>(this.url, cliente, HttpOptions);
  }

  deleteCliente(id: number): Observable<number> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, HttpOptions);
  }
}
