import { BrowserModule } from '@angular/platform-browser';
import { NgModule,LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {ROUTES} from './app.routes'
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { CardapioComponent } from './cardapio/cardapio.component';
import { FoodService } from './cardapio/food.service';
import { NotificacaoService } from './notificacao/notificacao.service'
import { CarrinhoService } from './carrinho/carrinho.service'
import { ToastyModule } from 'ng2-toasty'
import { NotificacaoComponent } from './notificacao/notificacao.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';
import { CheckoutComponent } from './checkout/checkout.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CardapioComponent,
    NotificacaoComponent,
    CarrinhoComponent,
    CheckoutComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot(ROUTES)
  ],
  providers: [FoodService,NotificacaoService,CarrinhoService,{provide:LOCALE_ID,useValue:'pt-BR'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
