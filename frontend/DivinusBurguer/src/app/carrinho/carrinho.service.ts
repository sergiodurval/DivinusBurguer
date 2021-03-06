import { ItemCarrinho } from "./itemCarrinho.model";
import { Food } from "app/cardapio/food.model";

export class CarrinhoService{

    
    itemCarrinho: Array<ItemCarrinho> = []


    adicionarCarrinho(food:Food):void{
        var item = new ItemCarrinho()
        item.food = food
        item.quantidade = 1
        if(this.containsFood(food) && this.itemCarrinho.length != 0){
          this.incrementarQuantidade(food.id)
        }else{
          this.itemCarrinho.push(item)
        } 
    }

    ObterItens():ItemCarrinho[]{
        return this.itemCarrinho
    }

    removerItemCarrinho(id:string):ItemCarrinho[]{
     
      for(let item of this.itemCarrinho){
        if(item.food.id == id){
          item.quantidade = item.quantidade - 1
          if(item.quantidade == 0){
            this.itemCarrinho.splice(this.itemCarrinho.indexOf(item),1)
          }
        }
      }
      
      return this.itemCarrinho
    }

    incrementarQuantidade(id:string):ItemCarrinho[]{

      for(let item of this.itemCarrinho){
        if(item.food.id == id){
          item.quantidade = item.quantidade + 1
          
        }
      }
      
      return this.itemCarrinho

    }


    calculoTotal():number{
      
      let total = 0
      for(let item of this.itemCarrinho){
         total += item.food.price * item.quantidade
      }
      
      return total
    }


    containsFood(food:Food):boolean{
       for(let f of this.itemCarrinho){
           if(f.food.id == food.id){
             return true
           }
       }
       return false
    }

    esvaziarCarrinho():void{
      this.itemCarrinho = []
    }


}