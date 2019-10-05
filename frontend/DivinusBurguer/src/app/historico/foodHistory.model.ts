import { Food } from "app/cardapio/food.model";

export interface FoodHistory{
    foods:Food[]
    paymentMethod:string
    totalValue:number
    orderDate:string
    orderNumber:number
}