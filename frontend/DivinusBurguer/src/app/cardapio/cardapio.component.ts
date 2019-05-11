import { Component, OnInit, Input } from '@angular/core';
import { Food } from './food.model';
import { FoodService } from './food.service';

@Component({
  selector: 'app-cardapio',
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.css']
})
export class CardapioComponent implements OnInit {

  foods : Food[]

  constructor(private foodService:FoodService) { }

  ngOnInit() {
    this.foodService.foods()
    .subscribe(foods => this.foods = foods)
  }

}
