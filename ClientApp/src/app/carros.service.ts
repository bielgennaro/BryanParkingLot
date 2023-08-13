import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Carros} from "./Carros";

const HttpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CarrosService {

  url: string = "https://localhost:7137/api/carros";

  constructor(private http: HttpClient) {
  }

  getCarros(): Observable<Carros[]> {
    return this.http.get<Carros[]>(this.url);
  }

  getCarroById(id: number): Observable<Carros> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<Carros>(apiUrl);
  }

  createCarro(carro: Carros): Observable<Carros> {
    return this.http.post<Carros>(this.url, carro, HttpOptions);
  }

  updateCarro(carro: Carros): Observable<Carros> {
    return this.http.put<Carros>(this.url, carro, HttpOptions);
  }

  deleteCarro(id: number): Observable<number> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, HttpOptions);
  }
}
