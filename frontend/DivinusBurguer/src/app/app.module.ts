import { BrowserModule } from '@angular/platform-browser';
import { NgModule,LOCALE_ID, ErrorHandler } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
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
import { AddressService } from './checkout/address.service';
import { LoginComponent } from './login/login.component';
import { AuthenticationService} from './login/authentication.service'
import { APP_BASE_HREF, Location } from '@angular/common';
import {ApplicationErrorHandler} from './app.error-handle';
import { RegisterComponent } from './register/register.component'
import { OrderService } from './checkout/order.service';
import { OrderSummaryComponent } from './order-summary/order-summary.component';
import { HistoricoComponent } from './historico/historico.component'
import { FoodHistoryService } from './historico/foodHistory.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CardapioComponent,
    NotificacaoComponent,
    CarrinhoComponent,
    CheckoutComponent,
    LoginComponent,
    RegisterComponent,
    OrderSummaryComponent,
    HistoricoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot(ROUTES)
  ],
  providers: [FoodService,NotificacaoService,CarrinhoService,AddressService,AuthenticationService,OrderService,FoodHistoryService,{provide:LOCALE_ID,useValue:'pt-BR'},{ provide: APP_BASE_HREF, useValue: window['_app_base'] || '/' },{provide:ErrorHandler,useClass: ApplicationErrorHandler}],
  bootstrap: [AppComponent]
})
export class AppModule { }
