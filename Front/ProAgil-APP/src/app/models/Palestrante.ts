import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {
  id: number;
  nome: string;
  miniCurriculo: string;
  imagemURL: string;
  telefone: string;
  email: string;
  redesSoiais: RedeSocial[];
  palestrantesEventos: Evento[];
}
