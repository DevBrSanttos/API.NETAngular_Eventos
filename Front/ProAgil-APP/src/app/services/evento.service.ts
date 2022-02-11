import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(
  //{ providedIn: 'root'}
)
export class EventoService {
  baseURL = 'http://localhost:5000/api/eventos';

  constructor(private http: HttpClient) { }

  // pegando dados do evento da API .NET
  public getEventos(): Observable<Evento[]>{
    return this.http.get<Evento[]>(this.baseURL);
  }

  public getEventosByTema(tema: string): Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseURL}/tema/${tema}`);
  }

  public getEventoById(id: number): Observable<Evento>{
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }

}
