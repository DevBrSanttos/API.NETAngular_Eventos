import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: any = [];

  constructor(private http: HttpClient) { }

  // metodo que executa antes do HTML
  ngOnInit() {
    this.getEventos();
  }

  getEventos(){
    // pegando dados do evento da API .NET
    this.http.get('http://localhost:5000/api/values').subscribe(
      response => {
        this.eventos = response
      },
      error =>{
        console.log(error);
      });
  }

}
