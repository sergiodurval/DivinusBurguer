import { Component, OnInit } from '@angular/core';
import { CarrinhoService } from 'app/carrinho/carrinho.service';
import { ItemCarrinho } from '../carrinho/itemCarrinho.model';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';
import { AddressService } from './address.service';
import { Address } from './address.model'
import { Order} from './order.model'
import { User } from 'app/login/user.model';
import { AuthenticationService } from 'app/login/authentication.service';
import { Router, NavigationEnd } from '@angular/router';
import { OrderService } from './order.service';
import { PurchaseOrder } from './purchaseOrder.model';

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
  address = new Address()
  listaEstados : Array<string>
  estadoSelecionado:string
  formaPagamento:string
  isLogged : boolean
  user: User
  
  constructor(private carrinhoService:CarrinhoService,
              private toastyService:ToastyService, 
              private toastyConfig: ToastyConfig,
              private addressService:AddressService,
              private authenticationService: AuthenticationService,
              private router: Router,
              private orderService: OrderService) {
                this.router.events.subscribe((e) => {
                  if (e instanceof NavigationEnd) {
                      if(this.authenticationService.isLoggedIn()){
                        this.user = this.authenticationService.getUser()
                      }
                  }
               });
               
               }

  ngOnInit() {
    if(this.user != undefined){
      this.isLogged = true
    }

    this.itemCarrinho = this.carrinhoService.ObterItens()
    this.valorTotal = this.carrinhoService.calculoTotal()
    this.quantidadeItens = this.itemCarrinho.length
    this.listaEstados = this.addressService.getState()
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


  buscaEndereco(cep:string):void{
      if(cep.length == 8){
        this.addressService.getAddress(cep)
        .subscribe((data:Address) => this.address = data)
      }
  }

  finalizarPedido():void{
     let purchaseOrderList = new PurchaseOrder().convertToPurchaseOrder(this.itemCarrinho)
     let newOrder = new Order(this.address,this.formaPagamento,purchaseOrderList,this.valorTotal,this.user.id);
     this.orderService.createOrder(newOrder,this.user.token).subscribe(data =>{
         console.log(data)
     });
  }

  onSelectionChange(payment):void{
    this.formaPagamento = payment.id
  }

  logoff():void{
    this.authenticationService.logoff()
    this.router.navigate(['/'])
 }

}
