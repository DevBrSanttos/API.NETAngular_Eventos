import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  larguraImg: number = 100;
  margemImg: number = 2;
  exibirImg: boolean = true;
  private _filtroLista: string = "";

  constructor(private http: HttpClient) { }

  // metodo que executa antes do HTML
  ngOnInit() {
    this.getEventos();

  }

  alterarEstadoImg(){
    this.exibirImg = !this.exibirImg;
  }

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento : any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  getEventos(){
    // pegando dados do evento da API .NET
    this.http.get('http://localhost:5000/api/values').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error =>{
        console.log(error);
      });
  }

}
