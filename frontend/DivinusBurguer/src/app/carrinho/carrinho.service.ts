import { ItemCarrinho } from "./itemCarrinho.model";
import { Food } from "app/cardapio/food.model";
export class CarrinhoService{

    
    itemCarrinho: Array<ItemCarrinho> = []


    adicionarCarrinho(food:Food):void{
        var item = new ItemCarrinho()
        item.food = food
        item.quantidade = 1
        this.itemCarrinho.push(item)
    }

    ObterItens():ItemCarrinho[]{
        return this.itemCarrinho
    }

    removerItemCarrinho(id:string):ItemCarrinho[]{
     
     var carrinhoFiltrado : Array<ItemCarrinho> = []

     for(let item of this.itemCarrinho){
       if(item.food.id != id){
         carrinhoFiltrado.push(item)
       }
     }

      return this.itemCarrinho = carrinhoFiltrado
    }


}