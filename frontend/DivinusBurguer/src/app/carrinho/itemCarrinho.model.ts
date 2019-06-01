import { Food } from "app/cardapio/food.model";

export class ItemCarrinho{
    food:Food;
    quantidade:number;
    

    constructor(){
        this.food = new Food()
    }

}