import { Component, OnInit, Input, Injectable } from '@angular/core';
import { Food } from './food.model';
import { FoodService } from './food.service';
import { NotificacaoService } from 'app/notificacao/notificacao.service';
import { CarrinhoService } from 'app/carrinho/carrinho.service';
import {ToastyService, ToastyConfig, ToastOptions, ToastData} from 'ng2-toasty';

@Component({
  selector: 'app-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.css'],
})

@Injectable()
export class CardapioComponent implements OnInit {

  foods : Food[]
  itemSelecionado : Food

  constructor(private foodService:FoodService , private notificationService:NotificacaoService,
              private carrinhoService:CarrinhoService,
              private toastyService:ToastyService, 
              private toastyConfig: ToastyConfig) { }

  ngOnInit() {
    this.foodService.foods()
    .subscribe(foods => this.foods = foods)
  }


  addCart(id:string):void{
     this.carrinhoService.adicionarCarrinho(this.getFood(id))
     this.addToast(this.getName(id))
  }

  getName(id:string):string{
     for(let food of this.foods){
       if(food.id == id){
         return food.name;
       }
     }
  }

  getFood(id:string):Food{
    for(let food of this.foods){
       if(food.id == id){
         return food;
       }
    }
  }

  addToast(title:string) {
    var toastOptions:ToastOptions = {
        title: title,
        msg: "Adicionado ao carrinho",
        showClose: true,
        timeout: 2000,
        theme: 'bootstrap',
        onAdd: (toast:ToastData) => {
            console.log('Toast ' + toast.id + ' has been added!');
        },
        onRemove: function(toast:ToastData) {
            console.log('Toast ' + toast.id + ' has been removed!');
        }
    };
    
    this.toastyService.success(toastOptions);
  }

}
