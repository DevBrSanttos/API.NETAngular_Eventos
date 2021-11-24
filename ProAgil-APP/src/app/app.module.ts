import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// minhas importações
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';

@NgModule({
  declarations: [	
    AppComponent,
    EventosComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule // Modulo que realiza as chamadas HTTP (acessar a API)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
