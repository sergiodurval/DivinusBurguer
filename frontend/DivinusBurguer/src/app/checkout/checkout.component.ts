import { Component, OnInit } from '@angular/core';
import { CarrinhoService } from 'app/carrinho/carrinho.service';
import { ItemCarrinho } from '../carrinho/itemCarrinho.model';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';
import { AddressService } from './address.service';
import { Address } from './address.model'
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  itemCarrinho: Array<ItemCarrinho>
  valorTotal:number = 0
  quantidadeItens:number = 0
  valorDesconto:number = 0
  cupom:string
  address: Address

  constructor(private carrinhoService:CarrinhoService,
              private toastyService:ToastyService, 
              private toastyConfig: ToastyConfig,
              private addressService:AddressService) { }

  ngOnInit() {
    this.itemCarrinho = this.carrinhoService.ObterItens()
    this.valorTotal = this.carrinhoService.calculoTotal()
    this.quantidadeItens = this.itemCarrinho.length
  }

  aplicarDesconto(cupom:string):void{
    console.log(cupom);
    this.cupom = cupom

    let desconto = 0
    switch(cupom){

      case "off10":{
        this.valorDesconto = 10
        this.addToast('aviso','cupom de R$10,00 aplicado com sucesso','sucesso')
        break;
      }

      case "off15":{
        this.valorDesconto = 15
        this.addToast('aviso','cupom de R$15,00 aplicado com sucesso','sucesso')
        break;
      }

      case "off20":{
        this.valorDesconto = 20
        this.addToast('aviso','cupom de R$20,00 aplicado com sucesso','sucesso')
        break;
      }

      default:{
        this.addToast('aviso','cupom de desconto inválido','erro')
        break;
      }
      
    }
    
    if(cupom != undefined || cupom != ''){
      this.valorTotal = this.valorTotal - this.valorDesconto
    }
    
  }


  addToast(titulo:string,mensagem:string,tipoAlerta:string) {
    var toastOptions:ToastOptions = {
        title: titulo,
        msg: mensagem,
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
    
    if(tipoAlerta == 'sucesso'){
      this.toastyService.success(toastOptions);
    }else{
      this.toastyService.error(toastOptions);
    }
  }


  buscaEndereco(cep:string):Address{

    if(cep.length == 8){
      this.addressService.getAddress(cep)
      .subscribe(address => this.address = address)
    }
    console.log(this.address)
    return this.address
  }

}
