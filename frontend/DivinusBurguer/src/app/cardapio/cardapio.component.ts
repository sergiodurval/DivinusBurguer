import { Component, OnInit, Input, Injectable } from '@angular/core';
import { Food } from './food.model';
import { FoodService } from './food.service';
import { NotificacaoService } from 'app/notificacao/notificacao.service';


@Component({
  selector: 'app-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.css'],
})

@Injectable()
export class CardapioComponent implements OnInit {

  foods : Food[]

  constructor(private foodService:FoodService , private notificationService:NotificacaoService) { }

  ngOnInit() {
    this.foodService.foods()
    .subscribe(foods => this.foods = foods)
  }


  addCart(id:string):void{
     this.notificationService.notificar(this.getName(id));
     console.log(id);
  }

  getName(id:string):string{
     for(let food of this.foods){
       if(food.id == id){
         return food.name;
       }
     }
  }

}
