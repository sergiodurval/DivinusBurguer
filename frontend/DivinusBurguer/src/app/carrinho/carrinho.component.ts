import { Component, OnInit,Injectable } from '@angular/core';
import { CarrinhoService } from './carrinho.service';
import { ItemCarrinho } from './itemCarrinho.model';
import { Food } from 'app/cardapio/food.model';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})

@Injectable()
export class CarrinhoComponent implements OnInit {
  
  itemCarrinho: Array<ItemCarrinho>
  food:Food
  total:number = 0

  constructor(private carrinhoService:CarrinhoService) { }

  ngOnInit() {
     this.itemCarrinho = this.carrinhoService.ObterItens()
     this.calculoTotal()
     console.log('itens no carrinho')
     console.log(this.carrinhoService.ObterItens())
  }

  calculoTotal():void{
    this.itemCarrinho = this.carrinhoService.ObterItens()
    this.total = 0
    for(let item of this.itemCarrinho){
       this.total += item.food.price * item.quantidade
    }
    
  }

  removerItem(id:string):void{
    console.log('removeu item: ')
    console.log(id)
    this.itemCarrinho = this.carrinhoService.removerItemCarrinho(id)
    this.calculoTotal()   
  }

  incrementarItem(id:string):void{
    this.itemCarrinho = this.carrinhoService.incrementarQuantidade(id)
    this.calculoTotal()
  }
  

}
