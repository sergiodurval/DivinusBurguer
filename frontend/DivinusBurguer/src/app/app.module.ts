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

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CardapioComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [FoodService,{provide:LOCALE_ID,useValue:'pt-BR'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
