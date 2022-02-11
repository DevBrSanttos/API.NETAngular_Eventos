import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
  //providers: [EventoService]
})
export class EventosComponent implements OnInit {

  modalRef: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public larguraImg: number = 100;
  public margemImg: number = 2;
  public exibirImg: boolean = true;
  private _filtroLista: string = "";

  constructor(private eventoService: EventoService,
              private modalService: BsModalService) { }

  // metodo que executa antes do HTML
  public ngOnInit(): void
  {
    this.getEventos();
  }

  public alterarEstadoImg(): void
  {
    this.exibirImg = !this.exibirImg;
  }

  public get filtroLista(): string
  {
    return this._filtroLista;
  }

  public set filtroLista(value: string)
  {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  private filtrarEventos(filtrarPor: string): Evento[]
  {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
                evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  // Pegando eventos da API .NET
  public getEventos(): void
  {
    this.eventoService.getEventos().subscribe(
      {
        next: (_eventos : Evento[]) => {
          this.eventos = _eventos;
          this.eventosFiltrados = this.eventos;
        },
        error: (error: any) =>{
          console.log(error);
        }
      });
  }


  // FUNÇÕES DE MODELS REFERENCIADOS PADRÕES
  // Chamar janela de confirmação ao clicar no Excluir
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
